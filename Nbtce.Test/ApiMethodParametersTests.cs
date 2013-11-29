using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBtce;
using NBtce.Attributes;
using NBtce.Mappers;
using NUnit.Framework;

namespace Nbtce.Test
{
    [TestFixture]
    public class ApiMethodParametersTests
    {
        [ApiRequest("fake")]
        class FakeApiRequest : ApiRequest<FakeResponse>
        {
            public const string SomeParameterProperty = "some_parameter";
            public const string SomeNullableIntProperty = "some_nullable_int";
            public const string SomeNullableDateTimeProperty = "some_nullable_datetime";

            [ApiParameter(SomeParameterProperty)]
            public string SomeParameter { get; set; }

            [ApiParameter(SomeNullableIntProperty)]
            public int? SomeNullableInt { get; set; }

            [ApiParameter(SomeNullableDateTimeProperty, ParameterMapper = typeof(FakeParameterMapper))]
            public DateTime? SomeDateTime { get; set; }
        }

        private class FakeResponse
        {
        }

        class FakeParameterMapper : IApiParameterMapper
        {
            public const string AlwaysReturn = "fake";
            public string MapToString(object parameter)
            {
                return AlwaysReturn;
            }
        }

        class FakeNonceProvider : INonceProvider
        {
            public long GetNext()
            {
                return 1;
            }
        }

        [Test]
        public void nothing_set()
        {
            // Arrange
            var request = new FakeApiRequest();

            // Act
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(2));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest["nonce"], Is.EqualTo("1"));
        }

        [Test]
        public void nothing_set_post_content()
        {
            // Arrange
            var method = new FakeApiRequest();
            var parameters = new ApiRequestParameters(method, new FakeNonceProvider());

            // Act
            var postContent = parameters.BuildPostContent();

            // Assert
            Assert.That(postContent, Is.EqualTo("method=fake&nonce=1"));
        }

        [Test]
        public void string_set_and_nullable_int_set()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            const int someNullableInt = 5;
            var request = new FakeApiRequest
                {
                    SomeParameter = someStringValue, 
                    SomeNullableInt = someNullableInt
                };

            // Act
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(4));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest["nonce"], Is.EqualTo("1"));
            Assert.That(apiRequest[FakeApiRequest.SomeParameterProperty] == someStringValue);
            Assert.That(apiRequest[FakeApiRequest.SomeNullableIntProperty] == someNullableInt.ToString());
        }

        [Test]
        public void string_set_and_nullable_int_set_post_content()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            const int someNullableInt = 5;
            var request = new FakeApiRequest
            {
                SomeParameter = someStringValue,
                SomeNullableInt = someNullableInt
            };
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Act
            var postContent = apiRequest.BuildPostContent();

            // Assert
            Assert.That(postContent, Is.EqualTo(
                "method=fake&nonce=1&" 
                + FakeApiRequest.SomeParameterProperty + "=" + someStringValue
                + "&" + FakeApiRequest.SomeNullableIntProperty + "=" 
                + someNullableInt.ToString(CultureInfo.InvariantCulture)));
        }   

        [Test]
        public void string_set_and_nullable_int_not_set()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            var request = new FakeApiRequest
                {
                    SomeParameter = someStringValue
                };

            // Act
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(3));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest["nonce"], Is.EqualTo("1"));
            Assert.That(apiRequest[FakeApiRequest.SomeParameterProperty] == someStringValue);
        }

        [Test]
        public void string_set_and_nullable_int_not_set_post_content()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            var request = new FakeApiRequest
            {
                SomeParameter = someStringValue
            };
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Act
            var postContent = apiRequest.BuildPostContent();

            // Assert
            Assert.That(postContent, Is.EqualTo(
                "method=fake&nonce=1&"
                + FakeApiRequest.SomeParameterProperty + "=" + someStringValue));
        }

        [Test]
        public void nullable_datetime_set_uses_parameter_mapper()
        {
            // Arrange
            var request = new FakeApiRequest
            {
                SomeDateTime = new DateTime(2013, 11, 25)
            };

            // Act
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(3));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest["nonce"], Is.EqualTo("1"));
            Assert.That(apiRequest[FakeApiRequest.SomeNullableDateTimeProperty] == FakeParameterMapper.AlwaysReturn);
        }

        [Test]
        public void nullable_datetime_set_uses_parameter_mapper_post_content()
        {
            // Arrange
            var request = new FakeApiRequest
            {
                SomeDateTime = new DateTime(2013, 11, 25)
            };
            var apiRequest = new ApiRequestParameters(request, new FakeNonceProvider());

            // Act
            var postContent = apiRequest.BuildPostContent();

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(3));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest["nonce"], Is.EqualTo("1"));
            Assert.That(apiRequest[FakeApiRequest.SomeNullableDateTimeProperty] == FakeParameterMapper.AlwaysReturn);

            Assert.That(postContent, Is.EqualTo(
                "method=fake&nonce=1&" +
                FakeApiRequest.SomeNullableDateTimeProperty + "=" + FakeParameterMapper.AlwaysReturn));
        }
    }
}

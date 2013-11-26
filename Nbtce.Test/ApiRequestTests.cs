using System;
using System.Collections.Generic;
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
    public class ApiRequestTests
    {
        [ApiRequest]
        class FakeApiRequest
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

        class FakeParameterMapper : IApiParameterMapper
        {
            public const string AlwaysReturn = "fake";
            public string MapToString(object parameter)
            {
                return AlwaysReturn;
            }
        }

        [Test]
        public void nothing_set()
        {
            // Arrange
            var request = new FakeApiRequest();

            // Act
            var apiRequest = new ApiRequest<FakeApiRequest>(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(0));
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
            var apiRequest = new ApiRequest<FakeApiRequest>(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(2));
            Assert.That(apiRequest[FakeApiRequest.SomeParameterProperty] == someStringValue);
            Assert.That(apiRequest[FakeApiRequest.SomeNullableIntProperty] == someNullableInt.ToString());
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
            var apiRequest = new ApiRequest<FakeApiRequest>(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(1));
            Assert.That(apiRequest[FakeApiRequest.SomeParameterProperty] == someStringValue);
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
            var apiRequest = new ApiRequest<FakeApiRequest>(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(1));
            Assert.That(apiRequest[FakeApiRequest.SomeNullableDateTimeProperty] == FakeParameterMapper.AlwaysReturn);
        }
    }
}

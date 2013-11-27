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
    public class ApiMethodParametersTests
    {
        [ApiRequest("fake")]
        class FakeApiMethod : ApiMethod<FakeResponse>
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

        [Test]
        public void nothing_set()
        {
            // Arrange
            var request = new FakeApiMethod();

            // Act
            var apiRequest = new ApiMethodParameters(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(1));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
        }

        [Test]
        public void string_set_and_nullable_int_set()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            const int someNullableInt = 5;
            var request = new FakeApiMethod
                {
                    SomeParameter = someStringValue, 
                    SomeNullableInt = someNullableInt
                };

            // Act
            var apiRequest = new ApiMethodParameters(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(3));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest[FakeApiMethod.SomeParameterProperty] == someStringValue);
            Assert.That(apiRequest[FakeApiMethod.SomeNullableIntProperty] == someNullableInt.ToString());
        }

        [Test]
        public void string_set_and_nullable_int_not_set()
        {
            // Arrange
            const string someStringValue = "some-string-value";
            var request = new FakeApiMethod
                {
                    SomeParameter = someStringValue
                };

            // Act
            var apiRequest = new ApiMethodParameters(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(2));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest[FakeApiMethod.SomeParameterProperty] == someStringValue);
        }

        [Test]
        public void nullable_datetime_set_uses_parameter_mapper()
        {
            // Arrange
            var request = new FakeApiMethod
            {
                SomeDateTime = new DateTime(2013, 11, 25)
            };

            // Act
            var apiRequest = new ApiMethodParameters(request);

            // Assert
            Assert.That(apiRequest.Count, Is.EqualTo(2));
            Assert.That(apiRequest["method"], Is.EqualTo("fake"));
            Assert.That(apiRequest[FakeApiMethod.SomeNullableDateTimeProperty] == FakeParameterMapper.AlwaysReturn);
        }
    }
}

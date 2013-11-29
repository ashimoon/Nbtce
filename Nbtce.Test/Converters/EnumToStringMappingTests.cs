using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBtce.Attributes;
using NBtce.Converters;
using NUnit.Framework;

namespace Nbtce.Test.Converters
{
    [TestFixture]
    public class EnumToStringMappingTests
    {
        enum EmptyEnum { }

        enum SingleMemberEnum
        {
            [JsonEnumValue("some_value")]
            First
        }

        enum EnumWithOneMissingAttribute
        {
            [JsonEnumValue("some_value")]
            Present,
            Missing
        }

        enum FullEnum
        {
            [JsonEnumValue("first_value")]
            First,
            [JsonEnumValue("second_value")]
            Second
        }

        [Test]
        public void empty_enum_has_no_values()
        {
            // Arrange
            
            // Act
            var mapping = new EnumToStringMapping<EmptyEnum>();

            // Assert
            Assert.That(mapping.Count, Is.EqualTo(0));
        }

        [Test]
        public void single_member_enum_has_single_member()
        {
            // Arrange

            // Act
            var mapping = new EnumToStringMapping<SingleMemberEnum>();

            // Assert
            Assert.That(mapping.Count, Is.EqualTo(1));
            Assert.That(mapping[SingleMemberEnum.First], Is.EqualTo("some_value"));
        }

        [Test]
        public void missing_one_attribute_throws_exception()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<MissingJsonEnumValueAttributeException>(() =>
                {
                    var mapping = new EnumToStringMapping<EnumWithOneMissingAttribute>();
                });
        }

        [Test]
        public void full_enum_has_all_values()
        {
            // Arrange
    
            // Act
            var mapping = new EnumToStringMapping<FullEnum>();

            // Assert
            Assert.That(mapping.Count, Is.EqualTo(2));
            Assert.That(mapping[FullEnum.First], Is.EqualTo("first_value"));
            Assert.That(mapping[FullEnum.Second], Is.EqualTo("second_value"));
        }
    }
}

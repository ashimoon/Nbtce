using NBtce.Attributes;

namespace NBtce.Model
{
    [JsonEnum]
    public enum SortOrder
    {
        [JsonEnumValue("ASC")]
        Ascending,
        [JsonEnumValue("DESC")]
        Descending
    }
}
using System.Collections.Generic;

namespace NBtce
{
    public class SortOrderParameterConverter : IApiParameterConverter<SortOrder>
    {
        private IDictionary<SortOrder, string> _mapping = new Dictionary<SortOrder, string>()
            {
                {SortOrder.Ascending, "ASC"},
                {SortOrder.Descending, "DESC"}
            }; 

        public string Convert(SortOrder input)
        {
            return _mapping[input];
        }
    }
}
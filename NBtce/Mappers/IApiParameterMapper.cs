namespace NBtce.Mappers
{
    public interface IApiParameterMapper<in TParameter>
    {
        string ToString(TParameter parameter);
    }
}
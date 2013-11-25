namespace NBtce
{
    public interface IApiParameterConverter<TInput>
    {
        string Convert(TInput input);
    }
}
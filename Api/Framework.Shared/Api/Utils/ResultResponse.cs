namespace Framework.Shared.Api.Utils;

public interface IResultReponse { }

public class ResultReponse<TResult> : IResultReponse
{
    public TResult Result { get; set; }
    
    public ResultReponse() { }

    public ResultReponse(TResult result)
    {
        Result = result;
    }
}
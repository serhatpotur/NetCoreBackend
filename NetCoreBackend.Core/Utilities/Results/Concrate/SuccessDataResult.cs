namespace NetCoreBackend.Core.Utilities.Results.Concrate;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message) : base(data, true, message)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }

    // default : T nesnesinin default değerini alır
    public SuccessDataResult(string message) : base(default, true, message)
    {
    }
    public SuccessDataResult() : base(default, true)
    {
    }
}

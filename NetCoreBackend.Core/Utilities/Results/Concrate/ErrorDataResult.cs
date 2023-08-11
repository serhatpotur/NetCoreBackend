namespace NetCoreBackend.Core.Utilities.Results.Concrate;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {
    }

    public ErrorDataResult(T data) : base(data, false)
    {
    }

    // default : T nesnesinin default değerini alır
    public ErrorDataResult(string message) : base(default, false, message)
    {
    }
    public ErrorDataResult() : base(default, false)
    {
    }
}

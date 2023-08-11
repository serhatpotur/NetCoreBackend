namespace NetCoreBackend.Core.Utilities.Results.Concrate;

// Base : Result classını ifade eder.Result sınıfına değer gönderiyoruz
public class SuccessResult : Result
{
    public SuccessResult(string message) : base(true, message)
    {

    }
    public SuccessResult() : base(true)
    {

    }
}

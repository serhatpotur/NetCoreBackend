using NetCoreBackend.Core.Utilities.Results.Abstract;

namespace NetCoreBackend.Core.Utilities.Business;

public static class BusinessRules
{
    public static IResult Run(params IResult[] logics)
    {
        foreach (var logic in logics)
        {
            if (!logic.Success)
            {
                // İş kuralı başarısız ise businessa haber ver
                return logic;
            }
        }
        return null;
    }
}

using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IRegionAggregate
    {
        Task<ApiResponse<IEnumerable<Region>>> GetAllResponse(CancellationToken cancellationToken);
    }
}
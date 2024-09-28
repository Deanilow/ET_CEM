using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        Task<ApiResponse<IEnumerable<Province>>> FindResponse(string RegionCode, CancellationToken cancellationToken);
    }
}
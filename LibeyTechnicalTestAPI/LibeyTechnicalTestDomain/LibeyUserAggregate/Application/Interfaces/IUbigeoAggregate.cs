using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        Task<ApiResponse<IEnumerable<Ubigeo>>> FindResponse(string ProvinceCode, CancellationToken cancellationToken);
    }
}
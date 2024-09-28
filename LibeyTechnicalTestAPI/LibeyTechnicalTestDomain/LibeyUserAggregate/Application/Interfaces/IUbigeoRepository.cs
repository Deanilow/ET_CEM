
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IUbigeoRepository
    {
        Task<IEnumerable<Ubigeo>> Find(string ProvinceCode, CancellationToken cancellationToken);
    }
}
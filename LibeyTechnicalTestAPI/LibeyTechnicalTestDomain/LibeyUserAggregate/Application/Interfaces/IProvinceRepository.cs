using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> Find(string RegionCode, CancellationToken cancellationToken);
    }
}
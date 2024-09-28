using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll(CancellationToken cancellationToken);
    }
}
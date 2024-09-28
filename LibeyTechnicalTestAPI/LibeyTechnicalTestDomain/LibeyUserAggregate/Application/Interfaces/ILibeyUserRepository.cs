using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        Task<IEnumerable<LibeyUser>> GetAll(CancellationToken cancellationToken);
        Task<IEnumerable<LibeyUser>> GetAllFilter(string textFilter, CancellationToken cancellationToken);
        Task<LibeyUser> Find(string documentNumber, CancellationToken cancellationToken);
        Task<LibeyUser> Create(LibeyUser libeyUser, CancellationToken cancellationToken);
        Task<LibeyUser> Update(LibeyUser libeyUser, CancellationToken cancellationToken);
        Task Delete(string documentNumber, CancellationToken cancellationToken);
    }
}
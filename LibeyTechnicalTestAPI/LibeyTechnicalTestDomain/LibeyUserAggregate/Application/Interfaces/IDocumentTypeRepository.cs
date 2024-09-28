using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Xml.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetAll(CancellationToken cancellationToken);
    }
}
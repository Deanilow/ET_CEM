using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IDocumentTypeAggregate
    {
        Task<ApiResponse<IEnumerable<DocumentType>>> GetAllResponse(CancellationToken cancellationToken);
    }
}
using AutoMapper;
using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;
        private readonly IMapper _IMapper;

        public DocumentTypeAggregate(IDocumentTypeRepository repository, IMapper IMapper)
        {
            _IMapper = IMapper;
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<DocumentType>>> GetAllResponse(CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<DocumentType>>(await _repository.GetAll(cancellationToken));
        }

    }
}
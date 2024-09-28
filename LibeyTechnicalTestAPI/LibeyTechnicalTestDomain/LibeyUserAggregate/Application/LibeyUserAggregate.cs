using AutoMapper;
using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper _IMapper;

        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper IMapper)
        {
            _IMapper = IMapper;
            _repository = repository;
        }
        public async Task<ApiResponse<LibeyUserResponse>> Create(UserUpdateorCreateCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.Find(command.DocumentNumber, cancellationToken);

            if (user is not null) return new ApiResponse<LibeyUserResponse>(null, "user already exists");

            var resultMapping = _IMapper.Map<LibeyUser>(command);

            var returnCreate = await _repository.Create(resultMapping, cancellationToken);

            return new ApiResponse<LibeyUserResponse>(_IMapper.Map<LibeyUserResponse>(returnCreate));
        }

        public async Task<ApiResponse<LibeyUserResponse>> Update(UserUpdateorCreateCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.Find(command.DocumentNumber, cancellationToken);

            if (user is null) return new ApiResponse<LibeyUserResponse>(null, "user does not exist", false);

            var resultMapping = _IMapper.Map<LibeyUser>(command);

            var returnUpdate = await _repository.Update(resultMapping, cancellationToken);

            return new ApiResponse<LibeyUserResponse>(_IMapper.Map<LibeyUserResponse>(returnUpdate));
        }

        public async Task<ApiResponse<bool>> Delete(string documentNumber, CancellationToken cancellationToken)
        {
            await _repository.Delete(documentNumber.Trim(), cancellationToken);

            return new ApiResponse<bool>(true);
        }

        public async Task<ApiResponse<IEnumerable<LibeyUserResponse>>> GetAllResponse(CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<LibeyUserResponse>>(_IMapper.Map<IEnumerable<LibeyUserResponse>>(await _repository.GetAll(cancellationToken)));
        }

        public async Task<ApiResponse<IEnumerable<LibeyUserResponse>>> GetAllFilterResponse(string textFilter, CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<LibeyUserResponse>>(_IMapper.Map<IEnumerable<LibeyUserResponse>>(await _repository.GetAllFilter(textFilter,cancellationToken)));
        }

        public async Task<ApiResponse<LibeyUserResponse>> FindResponse(string documentNumber, CancellationToken cancellationToken)
        {
            return new ApiResponse<LibeyUserResponse>(_IMapper.Map<LibeyUserResponse>(await _repository.Find(documentNumber.Trim(), cancellationToken)));
        }
    }
}
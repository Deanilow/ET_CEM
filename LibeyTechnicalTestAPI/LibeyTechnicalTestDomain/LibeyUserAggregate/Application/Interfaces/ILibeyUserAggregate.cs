using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        Task<ApiResponse<IEnumerable<LibeyUserResponse>>> GetAllResponse(CancellationToken cancellationToken);
        Task<ApiResponse<IEnumerable<LibeyUserResponse>>> GetAllFilterResponse(string textFilter, CancellationToken cancellationToken);
        Task<ApiResponse<LibeyUserResponse>> FindResponse(string documentNumber, CancellationToken cancellationToken);
        Task<ApiResponse<LibeyUserResponse>> Create(UserUpdateorCreateCommand command, CancellationToken cancellationToken);
        Task<ApiResponse<LibeyUserResponse>> Update(UserUpdateorCreateCommand command, CancellationToken cancellationToken);
        Task<ApiResponse<bool>> Delete(string documentNumber, CancellationToken cancellationToken);
    }
}
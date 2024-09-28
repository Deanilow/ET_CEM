using AutoMapper;
using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;
        private readonly IMapper _IMapper;

        public UbigeoAggregate(IUbigeoRepository repository, IMapper IMapper)
        {
            _IMapper = IMapper;
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<Ubigeo>>> FindResponse(string ProvinceCode, CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<Ubigeo>>(await _repository.Find(ProvinceCode, cancellationToken));
        }
    }
}
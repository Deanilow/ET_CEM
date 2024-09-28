using AutoMapper;
using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        private readonly IMapper _IMapper;

        public ProvinceAggregate(IProvinceRepository repository, IMapper IMapper)
        {
            _IMapper = IMapper;
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<Province>>> FindResponse(string RegionCode, CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<Province>>(await _repository.Find(RegionCode, cancellationToken));
        }
    }
}
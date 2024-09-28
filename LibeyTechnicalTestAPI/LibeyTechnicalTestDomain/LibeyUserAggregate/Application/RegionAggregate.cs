using AutoMapper;
using LibeyTechnicalTestDomain.Common;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        private readonly IMapper _IMapper;

        public RegionAggregate(IRegionRepository repository, IMapper IMapper)
        {
            _IMapper = IMapper;
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<Region>>> GetAllResponse(CancellationToken cancellationToken)
        {
            return new ApiResponse<IEnumerable<Region>>(await _repository.GetAll(cancellationToken));
        }

    }
}
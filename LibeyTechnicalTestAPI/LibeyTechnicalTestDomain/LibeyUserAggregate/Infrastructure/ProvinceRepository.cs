using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<Province>> Find(string RegionCode, CancellationToken cancellationToken)
        {
           return await _context.Province.Where(x => x.RegionCode == RegionCode).ToListAsync(cancellationToken);
        }
    }
}
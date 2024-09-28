using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<Ubigeo>> Find(string ProvinceCode, CancellationToken cancellationToken)
        {
           return await _context.Ubigeo.Where(x => x.ProvinceCode == ProvinceCode).ToListAsync(cancellationToken);
        }
    }
}
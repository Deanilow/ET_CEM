using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<LibeyUser> Create(LibeyUser libeyUser, CancellationToken cancellationToken)
        {
            await _context.LibeyUsers.AddAsync(libeyUser, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return libeyUser;
        }
        public async Task<LibeyUser> Find(string documentNumber, CancellationToken cancellationToken)
        {
            return await _context.LibeyUsers.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber && x.Active== true, cancellationToken);
        }

        public async Task<IEnumerable<LibeyUser>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.LibeyUsers.Where(x => x.Active == true).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<LibeyUser>> GetAllFilter(string textFilter, CancellationToken cancellationToken)
        {
            return await _context.LibeyUsers
             .Where(x => x.Active == true &&
                    (x.Name.Contains(textFilter) ||
                     x.DocumentNumber.Contains(textFilter) ||
                     x.FathersLastName.Contains(textFilter) ||
                     x.MothersLastName.Contains(textFilter)))
             .ToListAsync(cancellationToken);
        }

        public async Task Delete(string documentNumber, CancellationToken cancellationToken)
        {
            var user = await _context.LibeyUsers.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber, cancellationToken);

            if (user is not null)
            {
                user.DeleteUser();

                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<LibeyUser> Update(LibeyUser libeyUser, CancellationToken cancellationToken)
        {
            var user = await _context.LibeyUsers.FirstOrDefaultAsync(x => x.DocumentNumber == libeyUser.DocumentNumber);

            if (user is not null)
            {
                _context.Entry(user).CurrentValues.SetValues(libeyUser);

                await _context.SaveChangesAsync(cancellationToken);

                return libeyUser;
            }

            return null;
        }
    }
}
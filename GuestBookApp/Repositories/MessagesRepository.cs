using GuestBookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBookApp.Repositories
{
    public class MessagesRepository: IRepositoryMessages
    {
        private readonly GBContext _context;

        public MessagesRepository(GBContext context)
        {
            _context = context;
        }
        public async Task<List<Messages>> GetMessagesList()
        {
            return await _context.Messages.Include(p => p.User).ToListAsync();
        }

        public async Task Create(Messages c)
        {
            await _context.Messages.AddAsync(c);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

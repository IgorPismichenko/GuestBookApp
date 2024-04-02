using GuestBookApp.Models;

namespace GuestBookApp.Repositories
{
    public interface IRepositoryMessages
    {
        Task<List<Messages>> GetMessagesList();
        Task Create(Messages item);
        Task Save();
    }
}

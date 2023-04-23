using Webshop.API.Context;
using Webshop.API.Models.Entities;

namespace Webshop.API.Repositories
{
    public class MessageRepository
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> SendMessageAsync(MessageEntity newMessage)
        {
            try
            {
                _context.Messages.Add(newMessage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

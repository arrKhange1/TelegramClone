using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Data.Implementations
{
    public class ChatCategoryMSSQLRepository : IChatCategoryRepository
    {
        ApplicationContext _context;
        public ChatCategoryMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public ChatCategory GetChatCategoryById(Guid chatCategoryId)
        {
            return _context.ChatCategories.FirstOrDefault(chatCategory => chatCategory.ChatCategoryId == chatCategoryId);
        }
    }
}

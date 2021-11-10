using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services.Interfaces
{
    public interface IChatMessageService 
    {
        Task<string> FindUserIdByUsername(string username);

        Task<IEnumerable<ChatMessage>> GetAllMessagesForATicket(int id);//ticket id
        Task<ChatMessage> ReadChatMessage(int id);//cm id
        Task<int> CreateChatMessage(ChatMessage model);//returning the id of he created cm in order to be out in File
        Task EditChatMessage(ChatMessage model);//cm id
        Task DeleteChatMessage(int id);//cm id
    }
}

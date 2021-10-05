using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetAllTicketsWithUsername(string username);
        Task<string> FindUserIdByUsername(string username);
        Task<Ticket> ReadTicket(int id);//ticket id
        Task CreateTicket(Ticket model);
        Task EditTicket(Ticket model);//ticket id
        Task DeleteTicket(int id);//ticket id
    }
}

using Microsoft.EntityFrameworkCore;
using SoftwareCompanyTicketSystem.App.Services.Interfaces;
using SoftwareCompanyTicketSystem.Data;
using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;
        public TicketService(AppDbContext context)
        {
            _context = context;
        }
        //Read-repeated with chatmessage service
        public async Task<Ticket> ReadTicket(int id)
        {
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);

            if (ticket.Equals(null))
            {
                throw new NullReferenceException($"No ticket with id: {id}!");
            }
            else
            {
                return ticket;
            }
        }
        public async Task<int> CreateTicket(Ticket model)
        {
            Ticket ticket = new Ticket
            {
                Title = model.Title,
                Content = model.Content,
                AuthorId = model.AuthorId,
                SendOn = model.SendOn
            };
            //files hadling
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            int idOfCreatedTicket = ticket.TicketId;
            if (idOfCreatedTicket.Equals(null))
            {
                throw new NullReferenceException($"Error during creation of the Ticket!");
            }
            else
            {
                return idOfCreatedTicket;
            }
            
        }
        public async Task DeleteTicket(int id)
        {
            Ticket ticket = await ReadTicket(id);

            ticket.IsDeleted = true;
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task EditTicket(Ticket model)
        {
            Ticket ticket = await ReadTicket(model.TicketId);
            ticket.Title = model.Title;
            ticket.Content = model.Content;
            //files handling

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            IEnumerable<Ticket> tickets = await _context.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsWithUsername(string username)
        {
            IEnumerable<Ticket> tickets = await _context.Tickets.Where(t=>t.Author.UserName==username).ToListAsync();
            return tickets;
        }


        public async Task<string> FindUserIdByUsername(string username)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user.Equals(null))
            {
                throw new NullReferenceException($"No user with username: {username}!");
            }
            else
            {
                return user.Id;
            }
        }

    }
}

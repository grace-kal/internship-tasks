using Microsoft.EntityFrameworkCore;
using SoftwareCompanyTicketSystem.App.Services.Interfaces;
using SoftwareCompanyTicketSystem.Data;
using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly AppDbContext _context;
        public ChatMessageService(AppDbContext context)
        {
            _context = context;
        }
        //Read-repeated with ticket service
        public async Task<ChatMessage> ReadChatMessage(int id)
        {
            ChatMessage cm = await _context.ChatMessages.FirstOrDefaultAsync(cm => cm.ChatMessageId == id);
            if (cm.Equals(null))
            {
                throw new NullReferenceException($"No Chat message with id: {id}!");
            }
            else
            {
                return cm;
            }
        }
        public async Task<int> CreateChatMessage(ChatMessage model)
        {
            ChatMessage cm = new()
            {
                TicketId = model.TicketId,
                AuthorId = model.AuthorId,
                Content = model.Content,
                SendOn = model.SendOn

            };
            await _context.ChatMessages.AddAsync(cm);
            await _context.SaveChangesAsync();

            int idOfCreatedChatMessage = cm.ChatMessageId;
            if (idOfCreatedChatMessage.Equals(null))
            {
                throw new NullReferenceException($"Error during creation of the Chat Message!");
            }
            else
            {
                return idOfCreatedChatMessage;
            }
        }

        public async Task DeleteChatMessage(int id)
        {
            ChatMessage cm = await ReadChatMessage(id);

            cm.IsDeleted = true;
            _context.ChatMessages.Update(cm);
            await _context.SaveChangesAsync();
        }

        public async Task EditChatMessage(ChatMessage model)
        {
            ChatMessage cm = await ReadChatMessage(model.ChatMessageId);
            cm.Content = model.Content;

            _context.ChatMessages.Update(cm);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetAllMessagesForATicket(int id)
        {
            IEnumerable<ChatMessage> chatMessages = await _context.ChatMessages.Where(cm => cm.TicketId == id).ToListAsync();
            return chatMessages;

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

using SoftwareCompanyTicketSystem.App.Services.Interfaces;
using SoftwareCompanyTicketSystem.Data;
using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services
{
    public class FilePathService : IFilePathService
    {
        private readonly AppDbContext _context;
        public FilePathService(AppDbContext context)
        {
            this._context = context;
        }
        public async Task CreateFilePath(FilePath model)
        {
            FilePath fp = new()
            {
                ChatMessageId=model.ChatMessageId,
                Path=model.Path
            };
            await _context.FilePaths.AddAsync(fp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilePath(int filePathId)
        {
            throw new NotImplementedException();
        }
    }
}

using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Services.Interfaces
{
    public interface IFilePathService
    {
        Task CreateFilePath(FilePath model);
        Task DeleteFilePath(int filePathId);
    }
}

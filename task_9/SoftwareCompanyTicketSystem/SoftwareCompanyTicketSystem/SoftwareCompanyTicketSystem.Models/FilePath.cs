using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.Models
{
    public class FilePath
    {
        [Key]
        public int FilePathId { get; set; }

        [MinLength(5),MaxLength(100), Column(TypeName = "varchar")]
        public string Path { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("ChatMessage")]
        public int ChatMessageId { get; set; }
        public virtual ChatMessage ChatMessage { get; set; }
    }
}

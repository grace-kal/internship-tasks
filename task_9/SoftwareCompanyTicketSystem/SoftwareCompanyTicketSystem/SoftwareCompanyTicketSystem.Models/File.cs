using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.Models
{
    public class File
    {
        [Key]
        public int FileId { get; set; }

        [Required, Column(TypeName = "varchar"), MaxLength(250)]
        public string FileName { get; set; }

        [Required, Column(TypeName = "varbinary")]
        public string FilePic { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("ChatMessage"), Required]
        public int ChatMessageId { get; set; }
        public virtual ChatMessage ChatMessage { get; set; }
    }
}

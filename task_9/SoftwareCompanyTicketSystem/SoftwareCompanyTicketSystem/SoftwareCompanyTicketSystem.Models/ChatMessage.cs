using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            this.FilePaths = new List<FilePath>();
        }

        [Key]
        public int ChatMessageId { get; set; }

        [MaxLength(400), Column(TypeName = "nvarchar")]
        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SendOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<FilePath> FilePaths { get; set; }

        [ForeignKey("User")]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

    }
}

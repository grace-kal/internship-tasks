using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.Models
{
    public class Ticket
    {
        public Ticket()
        {
            this.ChatMessages = new List<ChatMessage>();
        }

        [Key]
        [Column(TypeName = "int")]
        public int TicketId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SendOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<ChatMessage> ChatMessages { get; set; }

        [ForeignKey("User")]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}

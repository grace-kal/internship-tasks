using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.SentTickets = new List<Ticket>();
            this.SentChatMessages = new List<ChatMessage>();
        }

        [Required,
         MaxLength(30, ErrorMessage = "Maximum length is 30 characters."),
         Column(TypeName = "varchar")]
        public string FName { get; set; }

        [Required,
         MaxLength(30, ErrorMessage = "Maximum length is 30 characters."),
         Column(TypeName = "varchar")]
        public string LName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime JoinedOn { get; set; }

        [Required]
        public bool IsApprovedByAdmin { get; set; }

        public string Level { get; set; }

        public string Affiliate { get; set; }

        public virtual List<Ticket> SentTickets { get; set; }

        public virtual List<ChatMessage> SentChatMessages { get; set; }



    }
}

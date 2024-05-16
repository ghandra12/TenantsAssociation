using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        public int UserId {  get; set; }

        public bool IsRead {  get; set; }
        public DateTime CreationDate { get; set; }
    }
}

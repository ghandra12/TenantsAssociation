using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class GetPollDto
    {
        public string Question { get; set; } = " ";
        public List<PollAnswerDto> Answers { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";
        public string Title { get; set; } = "";
     
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public  DateTime ExpirationDate { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.BusinessLogic.DTOs
{
    public class InvoiceDto
    {
        public string Description { get; set; } = "";
        public int InvoiceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Sum { get; set; }
    }
}
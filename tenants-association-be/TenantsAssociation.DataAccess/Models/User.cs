﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantsAssociation.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsAdmin { get; set; }
        public string PhoneNumber { get; set; } = "";
        public int? ApartmentNumber { get; set; }
        public byte[] PaswordSalt { get; set; }
    }
}

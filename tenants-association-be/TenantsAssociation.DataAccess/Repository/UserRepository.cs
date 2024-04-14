﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.DataAccess.IRepository;
using TenantsAssociation.DataAccess.Models;

namespace TenantsAssociation.DataAccess.Repository
{

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TenantsAssociationDBContext _db) : base(_db)
        {

        }
        public List<User> GetAdministrators()
        {
            return GetAll().Where(c => c.IsAdmin).ToList();
        }
        public bool VerifyUser(string email,string password)
        {
            return GetAll().Any(c => c.Email == email && c.Password == password);
        }
    }

}

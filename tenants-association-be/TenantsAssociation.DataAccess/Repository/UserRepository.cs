using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public List<User> GetTenants()
        {
            return GetAll().Where(c => c.IsAdmin == false).ToList();
        }

        public User? GetById(int userId)
        {
            return GetAll().FirstOrDefault(ur => ur.Id == userId);
        }
        public User? VerifyUser(string email, string password)
        {
            User? user = GetAll().SingleOrDefault(c => c.Email == email);

            if (user != null)
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: user.PaswordSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

                return user.Password == hashed ? user : null;
            }

            return null;
        }
    }

}

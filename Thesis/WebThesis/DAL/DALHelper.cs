using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebThesis.Models;

namespace WebThesis.DAL
{
    public class DALHelper
    {
        public bool ValidateUser(User usuario)
        {
            using (ThesisDbContext context = new ThesisDbContext())
            {
                return context.Users.Where(x => x.UserName == usuario.UserName && x.Password == usuario.Password).FirstOrDefault() != null;
            }
        }

        public List<Device> GetDevices()
        {
            using (ThesisDbContext context = new ThesisDbContext())
            {
                return context.Devices.Where(x => x.IsActive == true).ToList();
            }
        }

        public User GetUser(long id)
        {
            using (ThesisDbContext context = new ThesisDbContext())
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        internal void InsertUser(User user)
        {
            using (ThesisDbContext context = new ThesisDbContext())
            {
                context.Users.AddAsync(user);
                context.SaveChangesAsync();
            }
        }
    }
}

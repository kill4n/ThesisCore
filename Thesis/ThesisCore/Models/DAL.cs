using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ThesisCore.Models
{
    public class DAL
    {
        public bool ValidateUser(User usuario)
        {
            using (TesisContext context = new TesisContext())
            {
                return context.Users.AsNoTracking().Where(x => x.UserName == usuario.UserName && x.Password == usuario.Password).FirstOrDefault() != null;
            }
        }
        public User GetUser(long id)
        {
            using (TesisContext context = new TesisContext())
            {
                return context.Users.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<DataPotenciostato> GetPotData()
        {
            using (TesisContext context = new TesisContext())
            {
                return context.DataPotenciostatos.AsNoTracking().Select(x => x).ToList();
            }
        }

        public List<Device> GetDevices()
        {
            using (TesisContext context = new TesisContext())
            {
                return context.Devices.AsNoTracking().Select(x => x).ToList();
            }
        }
    }
}

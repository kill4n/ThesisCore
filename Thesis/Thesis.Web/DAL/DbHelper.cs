using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thesis.Web.Models;

namespace Thesis.Web.DAL
{
    public class DbHelper
    {
        public Users GetUsuario(int? id)
        {
            using (tesisEntities context = new tesisEntities())
            {
                return context.Users.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
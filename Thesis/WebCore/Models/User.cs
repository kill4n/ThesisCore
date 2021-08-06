using System;
using System.Collections.Generic;

#nullable disable

namespace WebCore.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

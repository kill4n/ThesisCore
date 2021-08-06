using System;
using System.Collections.Generic;

#nullable disable

namespace ThesisCore.Models
{
    public partial class Device
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Connected { get; set; }
        public long IdLocation { get; set; }
        public string Image { get; set; }
        public long IdUser { get; set; }
        public string ControllerToCall { get; set; }
    }
}

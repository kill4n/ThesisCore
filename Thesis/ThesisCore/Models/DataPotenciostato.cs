using System;
using System.Collections.Generic;

#nullable disable

namespace ThesisCore.Models
{
    public partial class DataPotenciostato
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime DateRun { get; set; }
        public string Description { get; set; }
        public string DataRun { get; set; }
    }
}

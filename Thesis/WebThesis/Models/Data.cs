using System;
using System.ComponentModel.DataAnnotations;

namespace WebThesis.Models
{
    public class Data
    {
        [Key]
        public long Id { get; set; }
        public long IdUser { get; set; }
        public DateTime DateRun { get; set; }
        public string Description { get; set; }
        public string DataRun { get; set; }
    }
}

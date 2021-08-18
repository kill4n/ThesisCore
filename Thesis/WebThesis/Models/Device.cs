using System;
using System.ComponentModel.DataAnnotations;

namespace WebThesis.Models
{
    public class Device
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsConnected { get; set; }
        public int Location { get; set; }
        public string Image { get; set; }
        public string Controller { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Thesis.Models.Data
{
    public class Device
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Device status 
        /// 0 -> Offline
        /// 1 -> Online
        /// 2 -> Busy
        /// </summary>
        [Required]
        public int State { get; set; }
        /// <summary>
        /// Id of user using the Device
        /// </summary>
        public long? UsedBy { get; set; }
        public DateTime? LastUsed { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebThesis.Models
{
    public class PotenciostatoModel
    {
        [DisplayName("Punto de Inicio"), RegularExpression("([1-9][0-9]*)")]
        public decimal StartPoint { get; set; }
        [DisplayName("Voltaje superior"), RegularExpression("([1-9][0-9]*)")]
        public decimal FirstVertex { get; set; }
        [DisplayName("Voltaje inferior"), RegularExpression("([1-9][0-9]*)")]
        public decimal SecondVertex { get; set; }
        [DisplayName("Cruces por cero"), RegularExpression("([1-9][0-9]*)")]
        public decimal ZeroCrosses { get; set; }
        [DisplayName("Scan rate"), RegularExpression("([1-9][0-9]*)")]
        public decimal ScanRate { get; set; }
        public List<Data> DataPotentiostat { get; set; }

    }
}

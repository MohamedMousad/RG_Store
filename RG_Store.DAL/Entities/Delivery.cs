using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Entities
{

    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public string ?DelivaryAddress { get; set; } 
        public DateTime ?DelivaryDate { get; set; }     
        public decimal ?DelivaryCost { get; set; }

        // DB relation
        [ForeignKey("Order")] 
        public int ?OrderId { get; set; }    
        public Order ?Order { get; set; }

    }
}

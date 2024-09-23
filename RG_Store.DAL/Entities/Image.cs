using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int ItemId { get; set; } 
        public Item Item { get; set; } 
    }
}

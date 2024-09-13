using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.ModelVM.OrderVM
{
    public class CreateOrderVM
    {
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<GetAllItemVM?> ?Items { get; set; }
    }
}

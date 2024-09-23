using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.DAL.Enums;

namespace RG_Store.BLL.ModelVM.OrderVM
{
    public class UpdateOrderVM
    {
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedOn { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<GetAllItemVM?> Items { get; set; }
    }
}

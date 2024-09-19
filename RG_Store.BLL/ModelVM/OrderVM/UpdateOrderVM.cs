using RG_Store.BLL.ModelVM.ItemVM;

namespace RG_Store.BLL.ModelVM.OrderVM
{
    public class UpdateOrderVM
    {
        public int OrderId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedOn { get; set; }

        public IEnumerable<GetAllItemVM?> Items { get; set; }
    }
}

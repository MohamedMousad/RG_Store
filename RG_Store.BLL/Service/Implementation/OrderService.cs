using AutoMapper;
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;

namespace RG_Store.BLL.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;
        private readonly ICartRepo cartRepo;

        public OrderService(IOrderRepo orderRepo, IMapper mapper, ICartRepo cartRepo)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
            this.cartRepo = cartRepo;
        }

        public async Task<bool> CreateOrder(int cartid, string userid)
        {
            return await orderRepo.CreateOrder(cartid, userid);
        }

        public async Task<bool> DeleteOrder(int orderid)
        {
            return await orderRepo.DeleteOrder(orderid);
        }

        public async Task<IEnumerable<GetAllItemVM>> GetAllOrderItem(int id)
        {
            var List = await orderRepo.GetAllOrderItem(id);
            List<GetAllItemVM> Res = new List<GetAllItemVM>();

            foreach (var item in List)
            {
                GetAllItemVM temp = new GetAllItemVM
                {
                    Name = item.Name,
                    FinalPrice = (decimal)item.FinalPrice,
                    IntialPrice = (decimal)item.IntialPrice,
                    ItemImage = item.ItemImage,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    HasOffer = item.HasOffer,
                    Offer = item.Offer,
                    Id = item.Id,
                };
                Res.Add(temp);
            }
            return Res;
        }

        public async Task<IEnumerable<GetOrderVM>> GetAllOrders()
        {
            var List = await orderRepo.GetAllOrders();

            List<GetOrderVM> Res = new List<GetOrderVM>();

            foreach (var item in List)
            {
                var temp = mapper.Map<GetOrderVM>(item);
                Res.Add(temp);
            }
            return Res;

        }

        public async Task<IEnumerable<GetOrderVM>> GetAllUserOrders(string userid)
        {
            var List = await orderRepo.GetAllUserOrders(userid);

            List<GetOrderVM> Res = new List<GetOrderVM>();

            foreach (var item in List)
            {
                var temp = mapper.Map<GetOrderVM>(item);
                Res.Add(temp);
            }
            return Res;
        }

        public async Task<Order> GetById(int id)
        {
            return await orderRepo.GetById(id);
        }

        public async Task<bool> UpdateOrder(Order orderid)
        {
            return await orderRepo.UpdateOrder(orderid);
        }

    }
}

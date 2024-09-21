using AutoMapper;
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;
using System.Collections.Generic;

namespace RG_Store.BLL.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;
        private readonly IUserRepo cartRepo;

        public OrderService(IOrderRepo orderRepo, IMapper mapper, IUserRepo cartRepo)
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
        public async Task<int> GetOrderCounts()
        {
            var list =await GetAllOrders();
            int cnt = 0;
            foreach(var order in list)
            {
                if(order.OrderStatus==DAL.Enums.OrderStatus.Completed) cnt++;              
            }
            return cnt; 
        }
        public async Task<decimal> GetTotalSales()
        {
            var list = await GetAllOrders();
            decimal Total = 0;
            foreach (var order in list)
            {
                if (order.OrderStatus == DAL.Enums.OrderStatus.Completed) Total += order.TotalCost;
            }
            return Total; 
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
                var user = await cartRepo.GetById(item.UserId);
                temp.OrderId = item.Id;

                temp.userName = user.UserName??""; 
                Res.Add(temp);
            }
            return Res;

        }

        public async Task<IEnumerable<GetOrderVM>> GetAllUserOrders(string userid)
        {
            var List = await orderRepo.GetAllUserOrders(userid);
       /*     var user = await cartRepo.GetById(userid);*/

            List<GetOrderVM> Res = new List<GetOrderVM>();

            foreach (var item in List)
            {
                var temp = mapper.Map<GetOrderVM>(item);
                temp.OrderId = item.Id;
                /*temp.userName = user.UserName ?? "";*/
                Res.Add(temp);
            }
            return Res;
        }

        public async Task<GetOrderVM> GetById(int id)
        {
            var ord = await orderRepo.GetById(id);
            var user = await cartRepo.GetById(ord.UserId);
            var res = mapper.Map<GetOrderVM>(ord);
            res.OrderId = ord.Id;
            res.userName = user.UserName ?? "Not Found";

            return res; 
        }

        public async Task<bool> UpdateOrder(UpdateOrderVM orderid)
        {
            var ord = await orderRepo.GetById(orderid.OrderId);
            ord.OrderStatus = orderid.OrderStatus;
            return await orderRepo.UpdateOrder(ord);
        }

    }
}

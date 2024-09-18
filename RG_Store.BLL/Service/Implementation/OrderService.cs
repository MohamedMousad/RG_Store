using AutoMapper;
using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;
using RG_Store.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;

        public OrderService(IOrderRepo orderRepo, IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
        }

        public bool Cancle(CancelOrderVM orderVM)
        {
            var Result = mapper.Map<Order>(orderVM);
            return /*orderRepo.UpdateOrder(Result);*/ true;
        }

        public bool Create(CreateOrderVM orderVM)
        {
            var Result = mapper.Map<Order>(orderVM);
          /*  return orderRepo.CreateOrder(Result);*/
            return /*orderRepo.UpdateOrder(Result);*/ true;
        }

        public GetOrderVM Get(int id)
        {
            var Item = orderRepo.GetById(id);
            var Result = mapper.Map<GetOrderVM>(Item);
            return Result;
        }

        public IEnumerable<GetOrderVM> GetAll()
        {
         /*   var List = orderRepo.GetAll().ToList();*/
            List<GetOrderVM> Result = new();
            /*foreach (var item in List)
            {
                var temp = mapper.Map<GetOrderVM>(item);
                Result.Add(temp);
            }*/
            return Result;
        }

        public bool Update(UpdateOrderVM orderVM)
        {
            var Result = mapper.Map<Order>(orderVM);
            return /*orderRepo.UpdateOrder(Result);*/ true;
        }
    }
}

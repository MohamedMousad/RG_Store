using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepo cartRepo;
        private readonly IMapper mapper;
        private readonly IItemRepo itemRepo;
        private readonly IItemService itemService;
        public CartService(ICartRepo carteRepo, IItemRepo itemRepo, IMapper mapper, IItemService itemService)
        {
            this.cartRepo = carteRepo;
            this.itemRepo = itemRepo;
            this.mapper = mapper;
            this.itemService = itemService;
        }
        public bool AddToCart(int ItemId, int id)
        {
            var item = itemService.GetAllItem(ItemId);
            var Result = mapper.Map<Item>(item);
            return cartRepo.AddToCart(Result, id);
            throw new NotImplementedException();
        }

        public bool ClearCart(int id)
        {
            return cartRepo.ClearCart(id);
        }

        public IEnumerable<GetAllItemVM> GetAll(int id)
        {
            var List = cartRepo.GetAllItems(id).ToList();
            List<GetAllItemVM> Resulte = new();
            foreach (var item in List)
            {
                var temp = mapper.Map<GetAllItemVM>(item);
                Resulte.Add(temp);
            }
            return Resulte;
        }

        public decimal? GetCartPrice(int id)
        {
            var List = cartRepo.GetAllItems(id).ToList();
            decimal? Total = 0;
            foreach(var  item in List)
            {
                Total += item.FinalPrice;
            }
            return Total; 
        }

        public bool RemoveFromCart(int ItemId, int id)
        {
            var item = itemService.GetAllItem(ItemId);
            var Result = mapper.Map<Item>(item);
            return cartRepo.RemoveFromCart(Result, id);
        }
    }
}

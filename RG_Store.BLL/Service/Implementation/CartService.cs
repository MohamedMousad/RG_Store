using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;

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
        public async Task<bool> AddToCart(int ItemId, int id)
        {
            var item = await itemRepo.GetById(ItemId);
            var Result = mapper.Map<Item>(item);
            return await cartRepo.AddToCart(Result, id);
        }



        public async Task<bool> ClearCart(int id)
        {
            return await cartRepo.ClearCart(id);
        }
        public async Task<IEnumerable<GetAllItemVM>> GetAllItems(int id)
        {
            var items = await cartRepo.GetAllItems(id);

            List<GetAllItemVM> result = new();
            foreach (var item in items)
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
                result.Add(temp);
            }

            return result;
        }
        public async Task<bool> RemoveFromCart(int ItemId, int id)
        {
            var item = await itemService.GetAllItem(ItemId);
            var Result = mapper.Map<Item>(item);
            return await cartRepo.RemoveFromCart(Result.Id, id);
        }
    }
}

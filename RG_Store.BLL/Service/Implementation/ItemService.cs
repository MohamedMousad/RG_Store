using AutoMapper;
using Entities;
using RG_Store.BLL.Images;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;

namespace RG_Store.BLL.Service.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IMapper mapper;

        private readonly IItemRepo Itemrepo;
        public ItemService(IMapper mapper, IItemRepo Itemrepo)
        {
            this.mapper = mapper;
            this.Itemrepo = Itemrepo;
        }

        //public bool Create(CreateItemVM createItemVM)
        //{
        //    createItemVM.Image = UploadImage.UploadFile("images", createItemVM.ItemImage);
        //    var Result = mapper.Map<Item>(createItemVM);

        //    return Itemrepo.Create(Result);
        //}

        public async Task<bool> Create(CreateItemVM createItemVM)
        {
            if (createItemVM.Image != null)
            {
                createItemVM.ItemImage = UploadImage.UploadFile("items", createItemVM.Image);
            }

            var Result = mapper.Map<Item>(createItemVM);
            return await Itemrepo.Create(Result);
        }

        public async Task<bool> Delete(DeleteItemVM deleteItem)
        {
            var Result = mapper.Map<Item>(deleteItem);
            return await Itemrepo.Delete(Result);
        }

        public async Task<IEnumerable<GetAllItemVM>> GetAll()
        {
            var List = await Itemrepo.GetAll();
            List<GetAllItemVM> Result = mapper.Map<List<GetAllItemVM>>(List);
            return Result;
        }

        public async Task<GetAllItemVM> GetAllItem(int id)
        {
            var item = await Itemrepo.GetById(id);
            var temp = mapper.Map<GetAllItemVM>(item);
            return temp;
        }

        public async Task<bool> Update(UpdateItemVM updateItem)
        {
            var Result = mapper.Map<Item>(updateItem);
            return await Itemrepo.Update(Result);
        }
    }
}

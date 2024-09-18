using AutoMapper;
using Entities;
using RG_Store.BLL.Images;
using RG_Store.BLL.Mapping;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Create(CreateItemVM createItemVM)
        {
            if (createItemVM.Image != null)
            {
                createItemVM.ItemImage = UploadImage.UploadFile("items", createItemVM.Image);
            }

            var Result = mapper.Map<Item>(createItemVM);
            return Itemrepo.Create(Result);
        }

        public bool Delete(DeleteItemVM deleteItem)
        {
            var Result = mapper.Map<Item>(deleteItem);
            return Itemrepo.Delete(Result);
        }

        public IEnumerable<GetAllItemVM> GetAll()
        {
            var List = Itemrepo.GetAll().ToList();
            List<GetAllItemVM> Result = mapper.Map<List<GetAllItemVM>>(List);
            return Result;
        }

        public GetAllItemVM GetAllItem(int id)
        {
            var item = Itemrepo.GetById(id);
            var temp = mapper.Map<GetAllItemVM>(item);
            return temp;
        }

        public bool Update(UpdateItemVM updateItem)
        {
            var Result = mapper.Map<Item>(updateItem);
            return Itemrepo.Update(Result);
        }
    }
}

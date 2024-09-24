using AutoMapper;
using RG_Store.BLL.ModelVM.CategoryVM;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;

namespace RG_Store.BLL.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepo categoryRepo;
        private readonly IItemRepo itemRepo;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper, IItemRepo itemRepo)
        {
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
            this.itemRepo = itemRepo;   
        }

        public async Task<bool> AddToCategory(int itemid, int id)
        {
            var itm = await itemRepo.GetById(itemid);
            return await categoryRepo.AddToCategory(itm, id);
        }

        public async Task<bool> Create(AddCategoryVM CategoryVM)
        {
            var cat = mapper.Map<Category>(CategoryVM);
            return await categoryRepo.Create(cat);  
        }

        public async Task<bool> Delete(DeleteCategoryVM CategoryVM)
        {
           return await categoryRepo.Delete(CategoryVM.Id);
        }

        public async Task<GetCategoryVM> Get(int id)
        {
            var cat = await categoryRepo.GetById(id) ;
            var ret = mapper.Map<GetCategoryVM>(cat);
            return ret; 
        }

        public async Task<IEnumerable<GetCategoryVM>> GetAll()
        {
            var list =await categoryRepo.GetAll();
            List<GetCategoryVM> ret =  new();
            foreach(var item in list) {
                var temp = mapper.Map<GetCategoryVM>(item);
                ret.Add(temp);
            
            }
            return ret;

        }

        public async Task<IEnumerable<GetAllItemVM>> GetAllItems(int id)
        {
            var list = await categoryRepo.GetAllItems(id);
            List<GetAllItemVM> ret = new();
            foreach (var item in list)
            {
                var temp = mapper.Map<GetAllItemVM>(item);
                ret.Add(temp);

            }
            return ret;
        }

        public async Task<bool> RemoveCategory(int itemid, int id)
        {
            var itm = await itemRepo.GetById(itemid);
            return await categoryRepo.RemoveFromCategory(itm, id);
        }

        public async Task<bool> Update(UpdateCategoryVM CategoryVM)
        {
            var cat = mapper.Map<Category>(CategoryVM);
            return await categoryRepo.Update(cat);
        }
    }
}

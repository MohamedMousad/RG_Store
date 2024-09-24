using AutoMapper;
using RG_Store.BLL.ModelVM.Category;
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

        public Task<bool> AddToCategory(GetAllItemVM item, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(AddCategoryVM CategoryVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(DeleteCategoryVM CategoryVM)
        {
            throw new NotImplementedException();
        }

        public GetCategoryVM Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategoryVM>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllItemVM>> GetAllItems(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCategory(int itemid, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateCategoryVM CategoryVM)
        {
            throw new NotImplementedException();
        }
    }
}

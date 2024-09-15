using RG_Store.BLL.ModelVM.Category;
using RG_Store.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface ICategoryService
    {
        public bool Create(AddCategoryVM CategoryVM);
        public GetCategoryVM Get(int id);
        public bool Update(UpdateCategoryVM CategoryVM);
        public bool Delete(DeleteCategoryVM CategoryVM);
        public IEnumerable<GetCategoryVM> GetAll();
    }
}

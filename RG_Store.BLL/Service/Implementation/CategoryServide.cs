﻿using AutoMapper;
using EmployeeSystem.DAL.Repo.Implementation;
using Entities;
using RG_Store.BLL.ModelVM.Category;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class CategoryServide : ICategoryServide
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepo categoryRepo;

        public CategoryServide(ICategoryRepo categoryRepo, IMapper mapper)
        {
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
        }

        public bool Create(AddCategoryVM CategoryVM)
        {
            var Result = mapper.Map<Category>(CategoryVM);
            return categoryRepo.Create(Result);
        }

        public bool Delete(DeleteCategoryVM CategoryVM)
        {
            var Result = mapper.Map<Category>(CategoryVM);
            return categoryRepo.Delete(Result);
        }

        public GetCategoryVM Get(int id)
        {
            var Item = categoryRepo.GetById(id);
            var Result = mapper.Map<GetCategoryVM>(Item);
            return Result;
        }

        public IEnumerable<GetCategoryVM> GetAll()
        {
            var List = categoryRepo.GetAll().ToList();
            List<GetCategoryVM> Result = new();
            foreach (var item in List)
            {
                var temp = mapper.Map<GetCategoryVM>(item);
                Result.Add(temp);
            }
            return Result;
        }
        public bool Update(UpdateCategoryVM CategoryVM)
        {
            var Result = mapper.Map<Category>(CategoryVM);
            return categoryRepo.Update(Result);
        }
    }
}

﻿using AutoMapper;
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepo favouriteRepo;
        private readonly IMapper mapper;
        private readonly IItemRepo itemRepo;
        private readonly IItemService itemService;
        public FavouriteService(IFavouriteRepo favouriteRepo, IItemRepo itemRepo, IMapper mapper, IItemService itemService)
        {
            this.favouriteRepo = favouriteRepo;
            this.itemRepo = itemRepo;
            this.mapper = mapper;
            this.itemService=itemService;
        }
        public async Task<bool> AddToFavorite(int ItemId,int id)
        {
           var item = itemService.GetAllItem(ItemId);
           var Result = mapper.Map<Item>(item);
           return await favouriteRepo.Add(Result,id);
        }

        public async Task<IEnumerable<GetAllItemVM>> GetAll(int id)
        {
            var List = await favouriteRepo.GetAll(id);
            List<GetAllItemVM> Resulte = new();
            foreach (var item in List)
            {
                var temp = mapper.Map<GetAllItemVM>(item);
                Resulte.Add(temp);
            }
            return Resulte;
        }

        public async Task<bool> RemoveFromFavorite(int ItemId, int id)
        {
            var item = itemService.GetAllItem(ItemId);
            var Result = mapper.Map<Item>(item);
            return await favouriteRepo.Remove(Result.Id, id);
        }
    }
}

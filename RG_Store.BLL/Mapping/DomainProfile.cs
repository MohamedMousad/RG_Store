using AutoMapper;
using System;
using RG_Store.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RG_Store.BLL.ModelVM.Category;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;
using RG_Store.BLL.ModelVM.UserVM;
using Entities;


namespace RG_Store.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //Cart Mapper
            /*  CreateMap<Cart, AddToCartVM>();
              CreateMap<Cart, ClearCartVM>();
              CreateMap<Cart, GetCartVM>();
              CreateMap<Cart, RemoveFromCartVM>();

              CreateMap<AddToCartVM, Cart>();
              CreateMap<ClearCartVM, Cart>();
              CreateMap<GetCartVM, Cart>();
              CreateMap<RemoveFromCartVM, Cart>();*/

            // User Mapper
            CreateMap<User, RegisterVM>();
            CreateMap<RegisterVM, User>();
            CreateMap<LoginVM, User>();
            CreateMap<User, LoginVM>();
            CreateMap<User, GetUserVM>();
            CreateMap<User, DeleteUserVM>();
            CreateMap<User, EditUserVM>();
            CreateMap<GetUserVM, User>();

            //Category Mapper
            CreateMap<Category, AddCategoryVM>();
            CreateMap<Category, DeleteCategoryVM>();
            CreateMap<Category, GetCategoryVM>();
            CreateMap<Category, UpdateCategoryVM>();
            
            // item
            CreateMap<Item, CreateItemVM>();
            CreateMap<Item, GetAllItemVM>();
            CreateMap<Item, UpdateItemVM>();
            CreateMap<Item, DeleteItemVM>();
            
            CreateMap<CreateItemVM, Item>();
            CreateMap<GetAllItemVM, Item>();
            CreateMap<UpdateItemVM, Item>();
            CreateMap<DeleteItemVM, Item>();

            //=====================================\\
            CreateMap<AddCategoryVM, Category>();
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<GetCategoryVM, Category>();
            CreateMap<UpdateCategoryVM, Category>();

            //Favourite Mapper
          /*  CreateMap<Favourite, AddToFavouriteVM>();
            CreateMap<Favourite, GetFavouriteVM>();
            CreateMap<Favourite, RemoveFromFavouriteVM>();

            CreateMap<AddToFavouriteVM , Favourite>();
            CreateMap<GetFavouriteVM, Favourite>();
            CreateMap<RemoveFromFavouriteVM, Favourite>();
*/
            //item Mapper
            CreateMap<Category, AddCategoryVM>();
            CreateMap<Category, DeleteCategoryVM>();
            CreateMap<Category, GetCategoryVM>();
            CreateMap<Category, UpdateCategoryVM>();
            CreateMap<Category, AddCategoryVM>();

            CreateMap<AddCategoryVM, Category>();
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<GetCategoryVM, Category>();
            CreateMap<UpdateCategoryVM, Category>();
            CreateMap<UpdateCategoryVM, Category>();

            //Order Mapper
            CreateMap<Order, CancelOrderVM>();
            CreateMap<Order, CreateOrderVM>();
            CreateMap<Order, UpdateOrderVM>();
            CreateMap<Order, GetOrderVM>();

            CreateMap<CancelOrderVM , Order>();
            CreateMap<CreateOrderVM, Order>();
            CreateMap<UpdateOrderVM, Order>();
            CreateMap<GetOrderVM, Order>();


            //User Mapper
         //   CreateMap<User, CreateUserVM>();
            CreateMap<User, DeleteUserVM>();
            CreateMap<User, EditUserVM>();
            CreateMap<User, GetUserVM>();
            CreateMap<User, LoginVM>();
            CreateMap<User, RegisterVM>();
            CreateMap<User, UpdateRoleVM>();

        }

    }
}

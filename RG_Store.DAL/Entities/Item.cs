﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RG_Store.DAL.Entities;

namespace Entities
{
    public class Item
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal? IntialPrice { get; set; } = 0;
        public decimal? FinalPrice { get; set; } = 0;
        public bool HasOffer { get; set; } = false;
        public decimal? Offer { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? ItemImage { get; set; }


        public FavouriteItem FavouriteItem { get; set; }
        public CartItem CartItem { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}

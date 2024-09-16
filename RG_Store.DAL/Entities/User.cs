using Microsoft.AspNetCore.Identity;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("User")]
    public class User:IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public Roles UserRole {  get; set; } 
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public string ?ProfileImage {  get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? Address { get; set; } = string.Empty;
        public Gender UserGender { get; set; } 

        public IEnumerable<Order?> ?Orders {  get; set; }

        public int ?CartId { get; set; }
        public virtual Cart? Cart { get; set; }
        public int ?FavouriteId { get; set; }
        public Favourite ?Favourite { get; set; }
        public string EmailConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
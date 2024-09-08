using Microsoft.AspNetCore.Identity;
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

        /*public string ?userGender { get; set; }*/
        /*        public virtual List<Order>? Orders { get; set; }*/
    }
}
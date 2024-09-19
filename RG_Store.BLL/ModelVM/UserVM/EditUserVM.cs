﻿using RG_Store.DAL.Enums;
using System.ComponentModel.DataAnnotations;


namespace RG_Store.BLL.ModelVM.UserVM
{
    public class EditUserVM
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; } = Roles.Customer.ToString(); // New property for Role
        public string? MyProperty { get; set; }
        public Gender UserGender { get; set; }

    }
}

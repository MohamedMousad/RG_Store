﻿using Microsoft.AspNetCore.Http;
using RG_Store.DAL.Enums;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class GetUserVM
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender UserGender { get; set; }
        public Roles? UserRole { get; set; }
        public string? Email { get; set; }
        public string? ProfileImage { get; set; }
        public IFormFile? Image { get; set; }
    }
}

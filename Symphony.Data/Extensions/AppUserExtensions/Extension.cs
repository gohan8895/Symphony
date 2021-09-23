using Symphony.Data.DTOs.AppUserDTOs;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Extensions.AppUserExtensions
{
    public static class Extension
    {
        public static AppUserDTO AsDTO(this AppUser appUser) => new AppUserDTO
        {
            Id = appUser.Id,
            FirstName = appUser.FirstName,
            LastName = appUser.LastName,
            DOB = appUser.DOB,
            PhoneNumber = appUser.PhoneNumber,
            Gender = appUser.Gender,
            Address = appUser.Address,
            Email = appUser.Email,
            UserName = appUser.UserName,
            EmailConfirmed = appUser.EmailConfirmed,
            CreatedAt = appUser.CreatedAt,
            UpdatedAt = appUser.UpdatedAt
        };
    }
}

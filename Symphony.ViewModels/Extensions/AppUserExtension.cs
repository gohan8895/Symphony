using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;

namespace Symphony.ViewModels.Extensions
{
    public static class AppUserExtension
    {
        public static AppUserVM AsVM(this AppUser appUser) => new AppUserVM
        {
            Id = appUser.Id,
            FirstName = appUser.FirstName,
            LastName = appUser.LastName,
            DOB = appUser.DOB,
            PhoneNumber = appUser.PhoneNumber,
            Gender = appUser.Gender,
            Address = appUser.Address,
            BatchId = appUser.BatchId.GetValueOrDefault(),
            Email = appUser.Email,
            UserName = appUser.UserName,
            EmailConfirmed = appUser.EmailConfirmed,
            CreatedAt = appUser.CreatedAt,
            UpdatedAt = appUser.UpdatedAt
        };
    }
}

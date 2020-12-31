using ArifOmer.BlogApp.DTO.Abstract;

namespace ArifOmer.BlogApp.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

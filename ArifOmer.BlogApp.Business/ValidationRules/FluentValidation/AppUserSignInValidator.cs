using ArifOmer.BlogApp.DTO.DTOs.AppUserDtos;
using FluentValidation;

namespace ArifOmer.BlogApp.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre Boş Geçilemez");
        }
    }
}

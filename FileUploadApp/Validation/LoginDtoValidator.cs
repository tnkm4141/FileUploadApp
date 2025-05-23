using FluentValidation;
using FileUploadApp.Dtos;

public class LoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
            .MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
    }
}

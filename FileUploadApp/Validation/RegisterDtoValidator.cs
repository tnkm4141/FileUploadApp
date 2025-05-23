using FluentValidation;
using FileUploadApp.Dtos;

public class RegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
            .MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakter olmalı");
       
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz")
            .MinimumLength(4).WithMessage("Şifre en az 4 karakter olmalı");
    }
}

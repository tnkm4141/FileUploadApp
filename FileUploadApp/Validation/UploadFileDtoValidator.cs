using FluentValidation;
using FileUploadApp.Dtos;

public class UploadFileDtoValidator : AbstractValidator<UploadFileDto>
{
    public UploadFileDtoValidator()
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("Dosya seçilmelidir.")
            .Must(file => file.Length > 0).WithMessage("Dosya boş olamaz.")
            .Must(file => file.Length < 5 * 1024 * 1024).WithMessage("Dosya 5MB'den büyük olamaz.");
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego.MyBooks.Domain.Models.Validations;

public class BookValidation : AbstractValidator<Book>
{
    public BookValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required")
            .Length(3, 150).WithMessage(" {PropertyName} need have in between {MinLength} an {MaxLength} character");
    }
}

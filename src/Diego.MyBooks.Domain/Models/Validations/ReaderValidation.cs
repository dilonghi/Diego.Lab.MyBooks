using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diego.MyBooks.Domain.Models.Validations;

public class ReaderValidation : AbstractValidator<Reader>
{
    public ReaderValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("The field {PropertyName} is required")
            .Length(3, 120).WithMessage(" {PropertyName} need have in between {MinLength} an {MaxLength} character");
    }
    }

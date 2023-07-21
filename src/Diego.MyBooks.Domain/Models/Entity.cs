using FluentValidation.Results;

namespace Diego.MyBooks.Domain.Models;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public ValidationResult ValidationResult { get; set; }
    public abstract bool IsValid();
}

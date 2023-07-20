using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Diego.MyBooks.Domain.Services;

public class BaseService
{
    private readonly INotifier _notifier;

    protected BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }

    protected void Notify(string mensagem)
    {
        _notifier.Handle(new Notification(mensagem));
    }

    protected bool NotificationExecute<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> 
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}

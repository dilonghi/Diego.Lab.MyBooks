using Diego.MyBooks.Domain.Interfaces;

namespace Diego.MyBooks.Domain.Notifications;

public class Notifier : INotifier
{
    private List<Notification> _notification;

    public Notifier()
    {
        _notification = new List<Notification>();
    }

    public void Handle(Notification notificacao)
    {
        _notification.Add(notificacao);
    }

    public List<Notification> GetNotifications()
    {
        return _notification;
    }

    public bool HaveNotification()
    {
        return _notification.Any();
    }
}

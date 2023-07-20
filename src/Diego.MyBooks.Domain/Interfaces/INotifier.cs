using Diego.MyBooks.Domain.Notifications;

namespace Diego.MyBooks.Domain.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notificacao);
}

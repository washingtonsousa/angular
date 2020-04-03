using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Kernel.Interfaces
{
  public interface IDomainNotificationHandler<T> : IHandler<T> where T : IDomainEvent
  {
    List<T> Notify();

    bool HasNotifications();

    string GetFirstNotification();

  }
}

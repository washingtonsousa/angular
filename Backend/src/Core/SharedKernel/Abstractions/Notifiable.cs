using Core.Shared.Kernel.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Shared.Kernel.Abstractions
{
    public abstract class Notifiable
    {
        [NotMapped]
        public bool Invalid { get; private set; }

        protected void AddNotification(params DomainNotification[] notifications)
        {
            Invalid = true;

            foreach(var notification in notifications)
            DomainEvent.DomainNotify(notification);
        }

    }
}

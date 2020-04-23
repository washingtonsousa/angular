using Core.Shared.Kernel.Interfaces;
using Core.SharedKernel.Interfaces;

namespace Core.Shared.Kernel.Events
{
  public static class DomainEvent 
  {
    public static IContainer Container;

    public static void Raise<T>(T args) where T : IDomainEvent
    {
        foreach (var handler in Container.GetServices<IHandler<T>>())
          ((IHandler<T>)handler).Handle(args);
    }

    public static void Notify<T>(T args) where T : IDomainEvent
    {

        foreach (var handler in Container.GetServices(typeof(IDomainNotificationHandler<T>)))
         ((IDomainNotificationHandler<T>)handler).Handle(args);
      
    }

  }
}

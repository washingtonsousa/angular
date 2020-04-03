using Core.Shared.Kernel.Enum;
using Core.Shared.Kernel.Interfaces;

namespace Core.Shared.Kernel.Events
{

  public class DomainNotification : IDomainEvent
  {
    public string Key { get; private set; }
    public string Value { get; private set; }
    public RankNotification Rank { get; private set; }

    public DomainNotification(string key, string value)
    {
      Key = key;
      Value = value;
    }

    public DomainNotification(string key, string value, RankNotification rank)
    {
      Key = key;
      Value = value;
      Rank = rank;
    }

    public DomainNotification(string value)
    {
      Value = value;
    }
  }
}

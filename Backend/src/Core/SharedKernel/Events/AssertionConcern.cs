using Core.Shared.Kernel.Enum;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Shared.Kernel.Events
{
  public  class AssertionConcern
  {
    public AssertionConcern() {

    }

    public static bool IsSatisfiedBy(params DomainNotification[] validations)
    {
      var notificationsNotNull = validations.Where(validation => validation != null);

      NotifyAll(notificationsNotNull);

      return notificationsNotNull.Count().Equals(0);
    }

    private  static void NotifyAll(IEnumerable<DomainNotification> notificationsNotNull)
    {
      notificationsNotNull.ToList().ForEach(validation =>
      {
        DomainEvent.DomainNotify(validation);
      });
    }

    public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message, string key = "AssertArgumentLength")
    {
      int length = stringValue.Trim().Length;

      return (length < minimum || length > maximum)
          ? new DomainNotification(key, message)
          : null;
    }

    public static DomainNotification AssertListLength<T>(IEnumerable<T> list, int minimum, string message, string key = "AssertArgumentLength", RankNotification rank = RankNotification.Low)
    {
      return (list == null || list.Count() <= minimum)
          ? new DomainNotification(key, message, rank)
          : null;
    }

    public static DomainNotification AssertMatches(string pattern, string stringValue, string message, string key = "AssertArgumentLength")
    {
      Regex regex = new Regex(pattern);

      return (!regex.IsMatch(stringValue))
          ? new DomainNotification(key, message)
          : null;
    }

    public static DomainNotification AssertNotEmpty(string stringValue, string message, string key = "AssertArgumentNotEmpty")
    {
      return (stringValue == null || stringValue.Trim().Length == 0)
          ? new DomainNotification(key, message)
          : null;
    }

    public static DomainNotification AssertNotNull(object object1, string message, string key = "AssertArgumentNotNull", RankNotification rank = RankNotification.Low)
    {
      return (object1 == null)
          ? new DomainNotification(key, message, rank)
          : null;
    }

    public static DomainNotification AssertTrue(bool boolValue, string message, string key = "AssertArgumentTrue", RankNotification rank = RankNotification.Low)
    {
      return (!boolValue)
          ? new DomainNotification(key, message, rank)
          : null;
    }

    public static DomainNotification AssertFalse(bool boolValue, string message, string key = "AssertArgumentTrue", RankNotification rank = RankNotification.Low)
    {
      return (boolValue)
          ? new DomainNotification(key, message, rank)
          : null;
    }

    public static DomainNotification AssertGenericException(string message, string key = "AssertArgumentGenericException")
    {
      return (message != null && message != "")
          ? new DomainNotification(key, message)
          : null;
    }
  
}
}

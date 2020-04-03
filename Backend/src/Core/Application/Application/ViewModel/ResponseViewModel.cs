using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Application.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel(object result, IList<DomainNotification> notifications = null)
        {
            _result = result;
            Notifications = notifications;
        }

        public object _result { get; set; }
        
        public IList<DomainNotification> Notifications { get; set; }


    }
}
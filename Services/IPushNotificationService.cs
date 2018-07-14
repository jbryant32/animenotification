using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;

namespace AnimeAratoBackend.Services
{
    /// <summary>
    /// request the delivaery
    /// </summary>
    public interface IPushNotificationService
    {
        void SendNotification(PushSubscription subscription, string payload);
    }
}

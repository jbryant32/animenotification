using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;
using Microsoft.Extensions.Options;

namespace AnimeAratoBackend.Services
{
    internal class WebPushPushNotificationService : IPushNotificationService
    {
        private readonly PushNotificationServiceOptions _options;
        private readonly WebPush.WebPushClient _pushClient;

        public WebPushPushNotificationService(IOptions<PushNotificationServiceOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;

            _pushClient = new WebPush.WebPushClient();
            _pushClient.SetVapidDetails(_options.Subject, _options.PublicKey, _options.PrivateKey);
        }
        public void SendNotification(PushSubscription subscription, string payload)
        {
            var webPushSubscription = new WebPush.PushSubscription(subscription.EndPoint, subscription.Keys["p256h"], subscription.Keys["auth"]);

            _pushClient.SendNotification(webPushSubscription, payload);
        }
    }
}

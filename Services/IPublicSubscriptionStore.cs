using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;

namespace AnimeAratoBackend.Services
{
    public interface IPublicSubscriptionStore
    {
        Task StoreSubscriptionAsync(PushSubscription pushSubscription);
        Task ForEachSubscriptionAsync(Action<PushSubscription> action);
    }
}

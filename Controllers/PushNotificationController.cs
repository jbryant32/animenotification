using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AnimeAratoBackend.Services;
using AnimeAratoBackend.Model;
namespace AnimeAratoBackend.Controllers
{
    public class PushNotificationController : Controller
    {
        private readonly IPublicSubscriptionStore publicSubscriptionStore;
        public PushNotificationController(IPublicSubscriptionStore publicSubscription)
        {
            this.publicSubscriptionStore = publicSubscription;
        }
        [HttpPost("StorePush")]
        public async Task<IActionResult> StoreSubscription([FromBody]PushSubscription pushSub)
        {
            await this.publicSubscriptionStore.StoreSubscriptionAsync(pushSub);
            return Ok();
        }
    }
}

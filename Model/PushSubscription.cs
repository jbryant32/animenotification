using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    public class PushSubscription
    {
        public string EndPoint { get; set; }
        public Dictionary<string, string> Keys { get; set; }
    }
}

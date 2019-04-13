using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;

namespace SOTNGamemode.Events
{
    class LCZHandler : IEventHandlerLCZDecontaminate
    {
        private SOTNGamemode plugin;

        public LCZHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnDecontaminate()
        {
            return;
        }
    }
}

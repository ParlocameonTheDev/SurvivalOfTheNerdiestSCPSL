using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace SOTNGamemode.Events
{
    class GeneratorHandler : IEventHandlerGeneratorFinish
    {
        private SOTNGamemode plugin;

        public GeneratorHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnGeneratorFinish(GeneratorFinishEvent ev)
        {
            if (Status.gamemodeEnabled)
            {
                Status.generatorsFinished++;
                if (Status.generatorsFinished == 5)
                {
                    Status.generatorsFinished = 0;
                    plugin.Server.Map.AnnounceCustomMessage("Lockdown disabled");
                    plugin.Server.Map.Broadcast(10, "Lockdown disabled, LCZ IS OPEN!, Go get an O5 to escape!", false);
                    Functions.Lockdown(false);
                }
            }
        }
    }
}

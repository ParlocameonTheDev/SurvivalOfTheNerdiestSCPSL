﻿using System;
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
                Functions.Lockdown(false);
            }
        }
    }
}

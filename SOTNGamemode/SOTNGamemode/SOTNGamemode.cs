using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.Config;
using Smod2.Commands;
using SOTNGamemode.Commands;
using Smod2.Attributes;
using SOTNGamemode.Events;
using Smod2.EventHandlers;

namespace SOTNGamemode
{
    [PluginDetails(
        author = "BinaryAssault",
		name = "Survival of The Nerdiest gamemode",
		description = "SCP-049-2 have infected the facility. Survive!",
		id = "binaryassault.gamemode.sotn",
		langFile = "OwnerFClass",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 3,
		SmodRevision = 1
    )]
    public class SOTNGamemode : Plugin
    {
        public static Config pluginConfig;
        public override void OnDisable()
        {
            Info("Survival of The Nerdiest disabled");
        }
        public override void OnEnable()
        {
            Info("Survival of The Nerdiest enabled");
            pluginConfig = new Config(this);
            pluginConfig.ReloadConfig();
        }

        public override void Register()
        {
            Functions.plugin = this;
            RegisterConfigs();
            RegisterEvents();
            RegisterCommands();
            
        }

        private void RegisterCommands()
        {
            this.AddCommand("sotnenable", new EnableGamemode(this));
        }
        private void RegisterConfigs()
        {
            this.AddConfig(new ConfigSetting("sotn_enabledatstart", false, true, "Enables gamemode automatically at start"));
            this.AddConfig(new ConfigSetting("sotn_scp049-2_hp", 675, true, "Enables gamemode automatically at start"));
            this.AddConfig(new ConfigSetting("sotn_scp049-2_damage", 45, true, "Enables gamemode automatically at start"));
        }
        private void RegisterEvents()
        {
            this.AddEventHandlers(new RoundEventHandler(this));
            this.AddEventHandlers(new InfectionHandler(this));
            this.AddEventHandlers(new GeneratorHandler(this));
            //this.AddEventHandler(typeof(IEventHandlerLCZDecontaminate), new LCZHandler(this));
            this.AddEventHandler(typeof(IEventHandlerDoorAccess), new DoorEventHandler(this));
            this.AddEventHandlers(new InfectionHandler(this));
            this.AddEventHandler(typeof(IEventHandlerTeamRespawn), new RespawnHandler(this));
            this.AddEventHandlers(new ConfigHandler(this));
            this.AddEventHandler(typeof(IEventHandlerCheckRoundEnd), new CheckEndRoundHandler(this));
        }
    }
}

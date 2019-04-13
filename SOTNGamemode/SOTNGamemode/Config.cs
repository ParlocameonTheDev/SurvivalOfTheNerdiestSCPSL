using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTNGamemode
{
    public class Config
    {
        private SOTNGamemode plugin;
        public int scp0492hp;
        public int scp0492damage;
        public Config(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }
        public void ReloadConfig()
        {
            int scp0492hp = plugin.GetConfigInt("sotn_scp049-2_hp");
            int scp0492damage = plugin.GetConfigInt("sotn_scp049-2_damage");
        }
    }
}

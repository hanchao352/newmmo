using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Entities;

namespace GameServer.AI
{
    class AIMonsterPassive:AIBase
    {
        public const string ID = "AIMonsterPassive";
        private Monster monster;

        public AIMonsterPassive(Monster monster):base(monster)
        {
           
        }
    }
}

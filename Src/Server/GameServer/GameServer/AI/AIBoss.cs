using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Entities;

namespace GameServer.AI
{
    class AIBoss:AIBase
    {
        public const string ID = "AIBoss";
       

        public AIBoss(Monster monster):base(monster)
        {
           
        }
    }
}

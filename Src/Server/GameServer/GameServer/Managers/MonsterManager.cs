using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data;
using GameServer.Entities;
using GameServer.Models;
using SkillBridge.Message;

namespace GameServer.Managers
{
    class MonsterManager : Singleton<MonsterManager>
    {
        private Map Map;
        public Dictionary<int, Monster> Monsters = new Dictionary<int, Monster>();

        internal void Init(Map map)
        {
            this.Map = map;
        }
        internal Monster Creat(int spawnID,int spawnLevel,NVector3 position,NVector3 direction)
        {
            Monster monster = new Monster(spawnID,spawnLevel,position,direction);
            EntityManager.Instance.AddEntity(this.Map.ID,monster);
            monster.Id = monster.entityId;
            monster.Info.EntityId = monster.entityId;
            monster.Info.mapId = this.Map.ID;
            Monsters[monster.Id] = monster;           
            this.Map.MonsterEnter(monster);
            return monster;
        }
    }
}

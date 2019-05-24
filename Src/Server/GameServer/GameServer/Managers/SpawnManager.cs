using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data;
using GameServer.Models;

namespace GameServer.Managers
{
    /// <summary>
    /// 刷怪管理器
    /// </summary>
    class SpawnManager 
    {
        private List<Spawner> Rules = new List<Spawner>();
        private Map Map;
        internal void Init(Map map)
        {
            this.Map = map;
            if (DataManager.Instance.SpawnRules.ContainsKey(map.Define.ID))
            {
                foreach (var define in DataManager.Instance.SpawnRules[map.Define.ID].Values)
                {

                    this.Rules.Add(new Spawner(define,this.Map));
                }
            }
        }

        internal void Update()
        {
            if (Rules.Count==0)
            {
                return;
            }
            for (int i = 0; i < this.Rules.Count; i++)
            {
                this.Rules[i].Update();
            }
        }
    }
}

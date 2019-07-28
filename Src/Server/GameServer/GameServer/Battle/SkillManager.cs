using GameServer.Entities;
using GameServer.Managers;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Battle
{
    class SkillManager
    {
        Creature Owner;
        public List<Skill> Skills { get; private set; }
        public List<NSkillInfo> Infos { get; private set; }


        public Skill NormalSkill { get; private set; }
        public SkillManager(Creature owner)
        {
            this.Owner = owner;
            this.Skills = new List<Skill>();
            this.Infos = new List<NSkillInfo>();
            this.InitSkills();
        }

        private void InitSkills()
        {
            this.Skills.Clear();
            this.Infos.Clear();

            ///数据库读取技能信息

            if (!DataManager.Instance.Skills.ContainsKey(this.Owner.Define.TID))
            {
                return;
            }

            foreach (var define in DataManager.Instance.Skills[this.Owner.Define.TID])
            {
                NSkillInfo info = new NSkillInfo();
                info.Id = define.Key;
                if (this.Owner.Info.Level>=define.Value.UnlockLevel)
                {
                    info.Level = 5;
                }
                else
                {
                    info.Level = 1;
                }
                this.Infos.Add(info);
                Skill skill = new Skill(info,this.Owner);
                if (define.Value.Type==Common.Battle.SkillType.Normal)
                {
                    NormalSkill = skill;
                }
                this.AddSkill(skill);
            }
        }

        private void AddSkill(Skill skill)
        {
            this.Skills.Add(skill);
        }

        internal Skill GetSkill(int skillId)
        {
            for (int i = 0; i < this.Skills.Count; i++)
            {
                if (this.Skills[i].Define.ID==skillId)
                {
                    return this.Skills[i];
                }
            }
            return null;
        }

        internal void Update()
        {
            for (int i = 0; i < this.Skills.Count; i++)
            {
                Skills[i].Update();
            }
        }
    }
}

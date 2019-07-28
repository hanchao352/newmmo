using Common.Data;
using GameServer.Core;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Managers;
using GameServer.Battle;
using Common.Battle;

namespace GameServer.Entities
{
    class Creature : Entity
    {

        public int Id { get; set; }
        public string Name { get { return this.Info.Name; } }

        

        public NCharacterInfo Info;
        public CharacterDefine Define;

        public Attributes Attributes;

        public SkillManager SkillMgr;

        public BuffManager BuffMgr;
        public EffectManager EffectMgr;
        public bool IsDeath = false;


        public BattleState BattleState;

        public CharacterState State;
        public Creature(CharacterType type, int configId, int level, Vector3Int pos, Vector3Int dir) :
           base(pos, dir)
        {
            this.Define = DataManager.Instance.Characters[configId];

            this.Info = new NCharacterInfo();
            this.Info.Type = type;
            this.Info.Level = level;
            this.Info.ConfigId = configId;
            this.Info.Entity = this.EntityData;
            this.Info.EntityId = this.entityId;         
            this.Info.Name = this.Define.Name;
            InitSkills();
            InitBuffs();

            this.Attributes = new Attributes();
            this.Attributes.Init(this.Define,this.Info.Level,this.GetEquips(),this.Info.attrDynamic);
            this.Info.attrDynamic = this.Attributes.DynamicAttr;
        }

       

        internal int Distance(Creature target)
        {
            return (int)Vector3Int.Distance(this.Position,target.Position);
        }
        internal int Distance(Vector3Int position)
        {
            return (int)Vector3Int.Distance(this.Position, position);
        }

        internal void DoDamage(NDamageInfo damage,Creature source)
        {
            this.BattleState = BattleState.InBattle;
            this.Attributes.HP -= damage.Damage;
            if (this.Attributes.HP<=0)
            {
                this.IsDeath = true;
                damage.WillDead = true;
            }
            this.OnDamage(damage,source);
        }

       

        void InitSkills()
        {
            SkillMgr = new SkillManager(this);
            this.Info.Skills.AddRange(SkillMgr.Infos);
        }

        private void InitBuffs()
        {
            BuffMgr = new BuffManager(this);
            EffectMgr = new EffectManager(this);
        }
        public virtual List<EquipDefine> GetEquips()
        {
            return null;
        }

        internal void CastSkill(BattleContext context, int skillId)
        {
            Skill skill = this.SkillMgr.GetSkill(skillId);
            context.Result = skill.Cast(context);
            if (context.Result==SkillResult.Ok)
            {
                this.BattleState = BattleState.InBattle;
            }
            if (context.CastSkill==null)
            {
                if (context.Result==SkillResult.Ok)
                {
                    context.CastSkill = new NSkillCastInfo()
                    {
                        casterId = this.entityId,
                        targetId = context.Target.entityId,
                        skillId = skill.Define.ID,
                        Position = new NVector3(),
                        Result = context.Result
                    };
                }

                context.Battle.AddCastSkillInfo(context.CastSkill);
            }
            else
            {
                context.CastSkill.Result = context.Result;
                context.Battle.AddCastSkillInfo(context.CastSkill);
            }
        }

        public override void Update()
        {
            this.SkillMgr.Update();
            this.BuffMgr.Update();
        }

        internal void AddBuff(BattleContext context, BuffDefine buffDefine)
        {
            this.BuffMgr.AddBuff(context,buffDefine);
        }

        protected virtual void OnDamage(NDamageInfo damage, Creature source)
        {
            
        }
    }
}

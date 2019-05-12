﻿using Common.Data;
using GameServer.Core;
using GameServer.Managers;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Entities
{
    /// <summary>
    /// Character
    /// 玩家角色类
    /// </summary>
    class Character : CharacterBase
    {
       
        public TCharacters Data;

        public ItemManager ItemManager;
        public Character(CharacterType type, TCharacters cha):
            base(new Core.Vector3Int(cha.MapPosX, cha.MapPosY, cha.MapPosZ),new Core.Vector3Int(100,0,0))
        {
            this.Data = cha;
            this.Info = new NCharacterInfo();
            this.Info.Type = type;
            this.Info.Id = cha.ID;
            this.Info.Name = cha.Name;
            this.Info.Level = 1;//cha.Level;
            this.Info.Tid = cha.TID;
            this.Info.Class = (CharacterClass)cha.Class;
            this.Info.mapId = cha.MapID;
            this.Info.Entity = this.EntityData;
            this.Define = DataManager.Instance.Characters[this.Info.Tid];

            this.ItemManager = new ItemManager(this);
            this.ItemManager.GetItemInfos(this.Info.Items);
            this.Info.Bag = new NBagInfo();
            this.Info.Bag.Unlocked = this.Data.Bag.Unlocked;
            this.Info.Bag.Items = this.Data.Bag.Items;
            Console.WriteLine("111");
        }
    }
}
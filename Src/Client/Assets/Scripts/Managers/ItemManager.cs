﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SkillBridge.Message;
using Models;
using Common.Data;
namespace Managers
{
    public class ItemManager:Singleton<ItemManager>
    {

        public Dictionary<int, Item> Items = new Dictionary<int, Item>();
        internal void Init(List<NItemInfo> items)
        {
            this.Items.Clear();
            foreach (var info in items)
            {
                Item item = new Item(info);
                this.Items.Add(item.Id,item);
                Debug.LogFormat("ItemManager: Init[{0}]",item);
            }
        }
        public ItemDefine GetItem()
        {
            return null;
        }
        public bool UseItem(int itemId)
        {
            return false;
        }
        public bool UseItem(ItemDefine item)
        {
            return false;
        }
    }
}

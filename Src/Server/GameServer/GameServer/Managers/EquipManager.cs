using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data;
using GameServer.Entities;
using Network;
using SkillBridge.Message;
using GameServer.Services;
namespace GameServer.Managers
{
    class EquipManager : Singleton<EquipManager>
    {
      
        public  Result EquipItem(NetConnection<NetSession> sender, int slot, int itemId, bool isEquip)
        {
            Character character = sender.Session.Character;
            if (!character.ItemManager.Items.ContainsKey(itemId))
            {
                return Result.Failed;
            }

            
            UpdateEquip(character.Data.Equips,slot,itemId,isEquip);            
            DBService.Instance.Entities.Entry(character.Data).State= System.Data.Entity.EntityState.Modified;           
            DBService.Instance.Save();
            return Result.Success;
        }

        //public byte[] UpdateEquip(byte[] equipData, int slot, int itemId, bool isEquip)
        //{
        //    byte[] bs = BitConverter.GetBytes(itemId);
        //    for (int i = slot* sizeof(int); i <( slot+1) *sizeof(int); i++)
        //    {
        //        equipData[i] = bs[i - sizeof(int) * slot];
        //    }
        //    return equipData;
        //}

        unsafe void UpdateEquip(byte[] equipData, int slot, int itemId, bool isEquip)
        {
            fixed (byte* pt = equipData)
            {
                int* slotid = (int*)(pt + slot * sizeof(int));
                if (isEquip)
                {
                    *slotid = itemId;
                }
                else
                {
                    *slotid = 0;
                }
            }
        }
    }
}

using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class TestManager : Singleton<TestManager>
    {
        public void Init()
        {
            NPCManager.Instance.RegisterNpcEvent(NpcFunction.InvokeShop,OnNpcInvokeShop);
            NPCManager.Instance.RegisterNpcEvent(NpcFunction.InvokeInsrance, OnNpcInvokeInsrance);
        }
        private bool OnNpcInvokeShop(NpcDefine npc)
        {
            Debug.LogFormat("TestManager.OnNpcInvokeShop:NPC:[{0}:{1}] Type:{2} Func:{3}",npc.ID,npc.Name,npc.Type,npc.Function);
           UITest test=  UIManager.Instance.Show<UITest>();
            test.SetTitle(npc.Name);
            return true;
        }
        private bool OnNpcInvokeInsrance(NpcDefine npc)
        {
            Debug.LogFormat("TestManager.OnNpcInvokeInsrance:NPC:[{0}:{1}] Type:{2} Func:{3}", npc.ID, npc.Name, npc.Type,npc.Function);
            MessageBox.Show("点击了NPC:"+npc.Name,"NPC对话");
            return true;
        }
       
    }
}


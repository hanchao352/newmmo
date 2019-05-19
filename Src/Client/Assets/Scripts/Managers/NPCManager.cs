﻿using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class NPCManager : Singleton<NPCManager>
    {

        public delegate bool NpcActionHandler(NpcDefine npc);
        Dictionary<NpcFunction, NpcActionHandler> eventMap = new Dictionary<NpcFunction, NpcActionHandler>();
        public void RegisterNpcEvent(NpcFunction function,NpcActionHandler action)
        {
            if (!eventMap.ContainsKey(function))
            {
                eventMap[function] = action;
            }
            else
            {
                eventMap[function] += action;
            }
        }
        // Use this for initialization
        public NpcDefine GetNpcDefine(int npcID)
        {
            NpcDefine npc = null;
            DataManager.Instance.NPCs.TryGetValue(npcID,out npc);
            return npc;
        }
        public bool Interactive(int npcId)
        {
            if (DataManager.Instance.NPCs.ContainsKey(npcId))
            {
                var npc = DataManager.Instance.NPCs[npcId];
                return Interactive(npc);
            }
            return false;
        }
        public bool Interactive(NpcDefine npc)
        {

            if (DoTaskInteractive(npc))
            {
                return true;
            }
            else if (npc.Type==NpcType.Functional)
            {
                return DoFunctionInteractive(npc);
            }
            return false;
        }

        public bool DoTaskInteractive(NpcDefine npc)
        {
            var status = QuestManager.Instance.GetQuestStatusByNpc(npc.ID);
            if (status==NpcQuestStatus.None)
            {
                return false;
            }
            return QuestManager.Instance.OpenNpcQuest(npc.ID);
        }
        public bool DoFunctionInteractive(NpcDefine npc)
        {
            if (npc.Type!=NpcType.Functional)
            {
                return false;
            }
            if (!eventMap.ContainsKey(npc.Function))
            {
                return false;
            }
            return eventMap[npc.Function](npc);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillBridge.Message;
using UnityEngine;
using UnityEngine.UI;

public class UIGuildItem : ListView.ListViewItem
{
    public NGuildInfo Info { get; internal set; }

    public override void onSelected(bool selected)
    {
        Debug.Log("1111");
    }
    public Text guildId;
    public Text guildName;
    public Text guidMembers;
    public Text leaderText;
    internal void SetGuildInfo(NGuildInfo item)
    {
        this.Info = item;
        guildId.text = item.Id.ToString();
        guildName.text = item.GuildName;
        guidMembers.text = string.Format("{0}/{1}",item.memberCount,item.Members.Count);
        leaderText.text = item.leaderName;
    }
}


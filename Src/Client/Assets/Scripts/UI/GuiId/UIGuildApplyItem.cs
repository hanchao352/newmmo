using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Services;
using SkillBridge.Message;
using UnityEngine;
using UnityEngine.UI;

class UIGuildApplyItem : ListView.ListViewItem
{
   


    NGuildApplyInfo Info;
   
    public Text Name;
    public Text @class;
    public Text level;
  
   

    internal void SetItemInfo(NGuildApplyInfo item)
    {
        this.Info = item;
        Name.text = this.Info.Name ;
        @class.text = this.Info.Class.ToString();
        level.text = this.Info.Level.ToString();
        
    }

    public void OnAccept()
    {
        MessageBox.Show(string.Format("要通过【{0}】的公会申请吗？",this.Info.Name),"审批申请",MessageBoxType.Confirm,"同意加入","取消").OnYes=()=> {
            GuildService.Instance.SendGuildJoinApply(true,this.Info);
        };
    }
    public void OnDecline()
    {
        MessageBox.Show(string.Format("要拒绝【{0}】的公会申请吗？", this.Info.Name), "审批申请", MessageBoxType.Confirm, "拒绝加入", "取消").OnNo = () =>
        {
            GuildService.Instance.SendGuildJoinApply(false, this.Info);
        };
    }
}


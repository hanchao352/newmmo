using SkillBridge.Message;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


 public class UIFriendItem:ListView.ListViewItem
 {
    public Text nickname;
    public Text @class;
    public Text level;
    public Text status;

    public Image background;
    public Sprite normalBg;
    public Sprite selecteBg;

    public NFriendInfo Info;
    public override void onSelected(bool selected)
    {
        this.background.overrideSprite = selected ? selecteBg : normalBg;
    }

    public void SetFriendInfo(NFriendInfo item)
    {
        this.Info = item;
        if (nickname != null) this.nickname.text = this.Info.friendInfo.Name;
        if (@class != null) this.@class.text = this.Info.friendInfo.Class.ToString();
        if (level != null) this.level.text = this.Info.friendInfo.Level.ToString();
        if (status  != null) this.status.text = this.Info.Status==1?"在线":"离线";
    }
}


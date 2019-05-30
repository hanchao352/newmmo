using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Managers;
using Services;
using System;

public class UIGuild : UIWindow
{
    public GameObject itemPrefab;
    public ListView listMain;
    public Transform itemRoot;
    public UIGuildInfo uiInfo;
    public UIGuildItem selectedItem;
    // Start is called before the first frame update
    void Start()
    {
        GuildService.Instance.OnGuildUpdate = UpdateUI;
        this.listMain.onItemSelected += this.OnGuildMemberSelected;
        this.UpdateUI();
    }

    private void OnDestroy()
    {
        GuildService.Instance.OnGuildUpdate = null;
    }
    // Update is called once per frame
    void UpdateUI()
    {
        this.uiInfo.Info = GuildManager.Instance.guildInfo;

        ClearList();
        InitItems();
    }
    private void OnGuildMemberSelected(ListView.ListViewItem item)
    {
        this.selectedItem = item as UIGuildItem;
    }
    private void InitItems()
    {
        foreach (var item in GuildManager.Instance.guildInfo.Members)
        {
            GameObject go = Instantiate(itemPrefab,this.listMain.transform);
            UIGuildMemberItem ui = go.GetComponent<UIGuildMemberItem>();
            ui.SetGuildMemberInfo(item);
            this.listMain.AddItem(ui);
        }
    }

    private void ClearList()
    {
        this.listMain.RemoveAll();
    }
    public void OnClickAppliesLits()
    {

    }

    public void OnClickLeave()
    {

    }
    public void OnClickChat()
    {

    }

    public void OnClickKickout()
    {

    }

    public void OnClickPromote()
    {

    }

    public void OnClickDepose()
    {

    }
    public void OnClickTransfer()
    {

    }

    public void OnClickSetNotice()
    {

    }

    
}

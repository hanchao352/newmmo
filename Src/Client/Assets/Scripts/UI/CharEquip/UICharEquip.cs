using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
using System;
using SkillBridge.Message;

public class UICharEquip : UIWindow
{
    public Text title;
    public Text money;

    public GameObject itemPrefab;
    public GameObject itemEquipPrefab;

    public Transform itemListRoot;
    public List<Transform> slots;
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
        EquipManager.Instance.OnEquipChanged += RefreshUI;
    }

    public void OnDestroy()
    {
        EquipManager.Instance.OnEquipChanged -= RefreshUI;
    }
    void RefreshUI()
    {
        ClearAllEquipLsit();
        InitAllEquipItems();
        ClearEquipedList();
        InitEquipedItems();
        this.money.text = User.Instance.CurrentCharacter.Gold.ToString();
    }

    /// <summary>
    /// 初始化所有装备列表
    /// </summary>
    private void InitAllEquipItems()
    {
        foreach (var kv in ItemManager.Instance.Items)
        {
            if (kv.Value.Define.Type==ItemType.Equip&&kv.Value.Define.LimitClass==User.Instance.CurrentCharacter.Class)
            {
                //已经装备就不显示了
                if (EquipManager.Instance.Contains(kv.Key))
                {
                    continue;
                }
                GameObject go = Instantiate(itemPrefab,itemListRoot);
                UIEquipItem ui = go.GetComponent<UIEquipItem>();
                ui.SetEquipItem(kv.Key,kv.Value,this,false);
            }
        }
    }


    private void ClearAllEquipLsit()
    {
        foreach (var item in itemListRoot.GetComponentsInChildren<UIEquipItem>())
        {
            Destroy(item.gameObject);
        }
    }

   

    private void ClearEquipedList()
    {
        foreach (var item in slots)
        {
            if (item.childCount>0)
            {
                Destroy(item.GetChild(0).gameObject);
            }
        }
    }
    /// <summary>
    /// 初始化已经装备的列表
    /// </summary>
    private void InitEquipedItems()
    {
        for (int i = 0; i < (int)EquipSlot.SlotMax; i++)
        {
            var item = EquipManager.Instance.Equips[i];
            {
                if (item!=null)
                {
                    GameObject go = Instantiate(itemEquipPrefab,slots[i]);
                    UIEquipItem ui = go.GetComponent<UIEquipItem>();
                    ui.SetEquipItem(i,item,this,true);
                }
            }
        }
    }

    public void DoEquip(Item item)
    {
        EquipManager.Instance.EquipItem(item);
    }
    public void UnEquip(Item item) 
    {
        EquipManager.Instance.UnEquipItem(item);
    }
}

using Managers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class UISkill:UIWindow
{
    public Text descript;
    public GameObject itemPrefab;
    public ListView listMain;
    private UISkillItem selectedItem;

    private void Start()
    {
        RefreshUI();
        this.listMain.onItemSelected += this.OnItemSelected;
    }


   

    public void OnDestroy()
    {
        
    }

    private void OnItemSelected(ListView.ListViewItem item)
    {
        this.selectedItem = item as UISkillItem;
        this.descript.text = this.selectedItem.item.Define.Description;
    }


    private void RefreshUI()
    {
        ClearItems();
        InitItems();
    }

    private void InitItems()
    {
        var Skills = User.Instance.CurrentCharacter.SkillMgr.Skills;
        foreach (var skill in Skills)
        {
            if (skill.Define.Type==Common.Battle.SkillType.Skill)
            {
                GameObject go = Instantiate(itemPrefab, this.listMain.transform);
                UISkillItem ui = go.GetComponent<UISkillItem>();
                ui.SetItem(skill, this,false);
                this.listMain.AddItem(ui);
            }
        }

    }

    private void ClearItems()
    {
        this.listMain.RemoveAll();
    }
}


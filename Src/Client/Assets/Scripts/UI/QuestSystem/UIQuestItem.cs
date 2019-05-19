using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Models;
public class UIQuestItem : ListView.ListViewItem
{
    public Text title;
    public Image background;
    public Sprite normalBg;
    public Sprite selectedBg;
    // Start is called before the first frame update

    public override void onSelected(bool selected)
    {
        this.background.overrideSprite = selected ? selectedBg : normalBg;
    }
    public Quest quest;
    void Start()
    {
        
    }

    public void SetQuestInfo(Quest item)
    {
        this.quest = item;
        if (this.title!=null)
        {
            this.title.text = this.quest.Define.Name;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

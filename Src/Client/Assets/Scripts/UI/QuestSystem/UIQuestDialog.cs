using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System;

public class UIQuestDialog : UIWindow
{
    // Start is called before the first frame update
    public UIQuestInfo questInfo;

    public Quest quest;

    public GameObject openButton;
    public GameObject submitbuttons;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        this.UpdateQuest();
        if (this.quest.Info==null)
        {
            openButton.SetActive(true);
            submitbuttons.SetActive(false);
        }
        else
        {
            if (this.quest.Info.Status == SkillBridge.Message.QuestStatus.Complated)
            {
                openButton.SetActive(false);
                submitbuttons.SetActive(true);
            }
            else
            {
                openButton.SetActive(false);
                submitbuttons.SetActive(false);
            }
        }
    }

    private void UpdateQuest()
    {
        if (this.quest!=null)
        {
            if (this.questInfo!=null)
            {
                this.questInfo.SetQuestInfo(quest);
            }
        }
    }
}

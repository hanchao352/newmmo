using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;
public class UIQuestStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] statusImage;
    private NpcQuestStatus questStatus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetQuestStatus(NpcQuestStatus status)
    {
        this.questStatus = status;
        for (int i = 0; i < 4; i++)
        {
            if (this.statusImage[i]!=null)
            {
                this.statusImage[i].gameObject.SetActive(i==(int)status);
            }
        }
    }
}

using Entities;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldElementManager : MonoSingleton<UIWorldElementManager>
{
    public GameObject nameBarPrefab;
    public GameObject npcStatusPrefab;
    public GameObject popupTextPrefab;

    private Dictionary<Transform, GameObject> elements = new Dictionary<Transform, GameObject>();
    private Dictionary<Transform, GameObject> elementStatus = new Dictionary<Transform, GameObject>();
    // Use this for initialization
    protected override void OnStart()
    {
        nameBarPrefab.SetActive(false);
        popupTextPrefab.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddCharacterNameBar(Transform owner, Character character)
    {
        GameObject goNameBar = Instantiate(nameBarPrefab, this.transform);
        goNameBar.name = "NameBar" + character.entityId;
        goNameBar.GetComponent<UIWorldElement>().owner = owner;
        goNameBar.GetComponent<UINameBar>().character = character;
        goNameBar.SetActive(true);
        this.elements[owner] = goNameBar;
    }

    public void RemoveCharacterNameBar(Transform owner)
    {
        if (this.elements.ContainsKey(owner))
        {
            Destroy(this.elements[owner]);
            this.elements.Remove(owner);
        }
    }

    public void AddNpcQuestStatus(Transform owner,NpcQuestStatus status)
    {
        if (this.elementStatus.ContainsKey(owner))
        {
            elementStatus[owner].GetComponent<UIQuestStatus>().SetQuestStatus(status);
        }
        else
        {
            GameObject go = Instantiate(npcStatusPrefab,this.transform);
            go.name = "NpcQuestStatus" + owner.name;
            go.GetComponent<UIWorldElement>().owner = owner;
            go.GetComponent<UIQuestStatus>().SetQuestStatus(status);
            go.SetActive(true);
            this.elementStatus[owner] = go;
        }
    }

    public void RemoveNpcQuestStatus(Transform owner)
    {
        if (this.elementStatus.ContainsKey(owner))
        {
            Destroy(this.elementStatus[owner]);
            this.elementStatus.Remove(owner);
        }
    }

    public void ShowPopupText(PopupType type,Vector3 position,float damage,bool isCrit)
    {
        GameObject goPopup = Instantiate(popupTextPrefab,position,Quaternion.identity,this.transform);
        goPopup.name = "Popup";
        goPopup.GetComponent<UIPopupText>().InitPopup(type,damage,isCrit);
        goPopup.SetActive(true);
    }
}

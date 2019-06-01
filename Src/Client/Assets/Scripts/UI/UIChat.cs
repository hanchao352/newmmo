using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candlelight.UI;
using Managers;
using UnityEngine;
using UnityEngine.UI;

 public class UIChat:MonoBehaviour
 {
    public HyperText textArea;//聊天内容显示区域

    public TabView cannelTab;

    public InputField chatText;//聊天输入控件

    public Text chatTarget;

    public Dropdown channelSelect;

    private void Start()
    {
        this.cannelTab.OnTabSelect += OnDisplayChannelSelected;
        ChatManager.Instance.OnChat += RefreshUI;
    }

    private void OnDestroy()
    {
        ChatManager.Instance.OnChat -= RefreshUI;
    }

    private void Update()
    {
        InputManager.Instance.IsInputMode = chatText.isFocused;
    }

    void OnDisplayChannelSelected(int idx)
    {
        ChatManager.Instance.displayChannel = (ChatManager.LocalChannel)idx;
        RefreshUI();
    }

    private void RefreshUI()
    {
        this.textArea.text = ChatManager.Instance.GetCurrentMessage();
        this.channelSelect.value = (int)ChatManager.Instance.sendChannel - 1;
        if (ChatManager.Instance.SendChannel==SkillBridge.Message.ChatChannel.Private)
        {
            this.chatTarget.gameObject.SetActive(true);
            if (ChatManager.Instance.PrivateID!=0)
            {
                this.chatTarget.text = ChatManager.Instance.PrivateName + ":";

            }
            else
            {
                this.chatTarget.text = "<无>";
            }
        }
        else
        {
            this.chatTarget.gameObject.SetActive(false);
        }
    }

    public void OnClickChatLink(HyperText text,HyperText.LinkInfo link)
    {
        if (string.IsNullOrEmpty(link.Name))
        {
            return;
        }

        //<a name="c:1001:Name" class="player">Name</a>

        //<a name="i:1001:Name" class="item">Name</a>
        if (link.Name.StartsWith("c:"))
        {
            string[] strs = link.Name.Split(":".ToCharArray());
            UIPopCharMenu menu = UIManager.Instance.Show<UIPopCharMenu>();
            menu.targetId = int.Parse(strs[1]);
            menu.targetName = strs[2];
        }
    }

    public void OnClickSend()
    {
        OnEndInput(this.chatText.text);
    }

    public void OnEndInput(string text)
    {
        if (!string.IsNullOrEmpty(text.Trim()))
        {
            this.SendChat(text);
        }
        this.chatText.text = "";
    }

    private void SendChat(string content)
    {
        ChatManager.Instance.SendChat(content,ChatManager.Instance.PrivateID,ChatManager.Instance.PrivateName);
    }
    public void OnSendChannelChanged(int idx)
    {
        Debug.Log(idx);
        if (ChatManager.Instance.sendChannel==(ChatManager.LocalChannel)(idx+1))
        {
            return;
        }
        if (!ChatManager.Instance.SetSendChannel((ChatManager.LocalChannel)idx + 1))
        {
            this.channelSelect.value = (int)ChatManager.Instance.sendChannel - 1;

        }
        else
        {
            this.RefreshUI();
        }
    }
}


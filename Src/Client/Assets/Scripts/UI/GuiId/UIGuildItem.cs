using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillBridge.Message;
using UnityEngine;
using UnityEngine.UI;

public class UIGuildItem : ListView.ListViewItem
{
    public NGuildInfo Info { get; internal set; }

    internal void SetGuildInfo(NGuildInfo item)
    {
        throw new NotImplementedException();
    }
}


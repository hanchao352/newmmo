
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

 class InputBox
{
    static Object cacheObject = null;
/// <summary>
/// 
/// </summary>
/// <param name="message"></param>
/// <param name="title"></param>
/// <param name="btnOk"></param>
/// <param name="btnCancle"></param>
/// <param name="emptyTips"></param>
/// <returns></returns>
    public static UIInputBox Show(string message, string title = "", string btnOk = "",string btnCancle="",string emptyTips="")
    {
        if (cacheObject==null)
        {
            cacheObject = Resloader.Load<Object>("UI/UIInputBox");
        }
        GameObject go = (GameObject)GameObject.Instantiate(cacheObject);
        UIInputBox inputBox = go.GetComponent<UIInputBox>();
        inputBox.Init(title,message,btnOk,btnCancle,emptyTips);
        return inputBox;
    }
}


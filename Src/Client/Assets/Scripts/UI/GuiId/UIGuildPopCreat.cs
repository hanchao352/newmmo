using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;
public class UIGuildPopCreat : UIWindow
{
    public InputField InputName;
    public InputField InputNotice;
    // Start is called before the first frame update
    void Start()
    {
        GuildService.Instance.OnGuildCreateResult = OnGuildCreated;
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        GuildService.Instance.OnGuildCreateResult = null;
    }

    public override void OnYesClick()
    {
        if (string.IsNullOrEmpty(InputName.text))
        {
            MessageBox.Show("请输入公会名","错误",MessageBoxType.Error);
            return;
        }
        if (InputName.text.Length<4||InputName.text.Length>10)
        {
            MessageBox.Show("公会名称为4-10个字符", "错误", MessageBoxType.Error);
            return;
        }
        if (string.IsNullOrEmpty(InputNotice.text))
        {
            MessageBox.Show("请输入公会宣言", "错误", MessageBoxType.Error);
            return;
        }
        if (InputNotice.text.Length < 3|| InputNotice.text.Length > 50)
        {
            MessageBox.Show("公会宣言需为3-20个字符", "错误", MessageBoxType.Error);
            return;
        }
        GuildService.Instance.SendGuildCreate(InputName.text,InputNotice.text);
    }

    void OnGuildCreated(bool result)
    {
        if (result)
        {
            this.Close(WindowResult.Yes);
        }
    }
}

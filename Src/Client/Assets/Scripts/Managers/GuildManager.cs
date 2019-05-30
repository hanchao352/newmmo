using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using SkillBridge.Message;

namespace Managers
{
    public class GuildManager : Singleton<GuildManager>
    {
        internal NGuildInfo guildInfo;

        public bool HasGuild
        {
            get { return this.guildInfo != null; }
        }


        internal void Init(NGuildInfo guild)
        {
            this.guildInfo = guild;
        }

        internal void ShowGuiId()
        {
            if (this.HasGuild)
                UIManager.Instance.Show<UIGuild>();
            else
            {
                var win = UIManager.Instance.Show<UIGuildPopNoGuild>();
                win.OnClose += PopNoGuild_OnClose;
            }
        }

        private void PopNoGuild_OnClose(UIWindow sender,UIWindow.WindowResult result)
        {
            if (result == UIWindow.WindowResult.Yes)
            {
                //创建公会
                UIManager.Instance.Show<UIGuildPopCreat>();
            }
            else if (result == UIWindow.WindowResult.No)
            {
                //加入公会
                UIManager.Instance.Show<UIGuildList>();
            }
        }
    }
}

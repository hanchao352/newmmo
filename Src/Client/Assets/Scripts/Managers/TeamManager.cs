using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using Common;
using SkillBridge.Message;
using Models;

namespace Managers
{
    class TeamManager : Singleton<TeamManager>
    {
        public void Init() { }

        internal void UpdateTeamInfo(NTeamInfo team)
        {
            User.Instance.TeamInfo = team;
            ShowTeamUI(team!=null);
        }

        private void ShowTeamUI(bool show)
        {
            if (UIMain.Instance!=null)
            {
                UIMain.Instance.ShowTeamUI(show);
            }
        }
    }
}

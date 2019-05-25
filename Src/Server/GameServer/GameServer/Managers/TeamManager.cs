using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Models;
using Common;
using Common.Data;
using SkillBridge.Message;
using Network;
using GameServer.Entities;

namespace GameServer.Managers
{
    class TeamManager : Singleton<TeamManager>
    {

        public List<Team> Teams = new List<Team>();
        public Dictionary<int, Team> CharacterTeams = new Dictionary<int, Team>();
        internal void Init()
        {
            
        }
        public Team GetTeamByCharacter(int characterId)
        {
            Team team = null;
            this.CharacterTeams.TryGetValue(characterId,out team);
            return team;
        }


        internal void AddTeamMember(Character leader, Character member)
        {
            if (leader.Team==null)
            {
                leader.Team = CreatTeam(leader);
            }
            leader.Team.AddMember(member);
        }
        Team CreatTeam(Character leader)
        {
            Team team = null;
            for (int i = 0; i < this.Teams.Count; i++)
            {
                team = this.Teams[i];
                if (team.Members.Count==0)
                {
                    team.AddMember(leader);
                    return team;
                }
            }
            team = new Team(leader);
            this.Teams.Add(team);
            team.Id = this.Teams.Count;
            return team;
        }
    }
}

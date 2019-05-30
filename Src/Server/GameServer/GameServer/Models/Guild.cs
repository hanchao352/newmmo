using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Entities;
using GameServer.Managers;
using SkillBridge.Message;
using GameServer.Services;
namespace GameServer.Models
{
    class Guild
    {
        public int Id { get { return this.Data.Id; } }
        private Character Leader;
        public string Name { get { return this.Data.Name; } }

        public List<Character> Members = new List<Character>();

        public double timestamp;
        public TGuild Data;

        public Guild(TGuild guild)
        {
            this.Data = guild;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillBridge.Message;

using Common;
using Common.Data;

using Network;
using GameServer.Managers;
using GameServer.Entities;
using GameServer.Services;

namespace GameServer.Models
{
    class Map
    {
        internal class MapCharacter
        {
            public NetConnection<NetSession> connection;
            public Character character;

            public MapCharacter(NetConnection<NetSession> conn, Character cha)
            {
                this.connection = conn;
                this.character = cha;
            }
        }

        public int ID
        {
            get { return this.Define.ID; }
        }
        internal MapDefine Define;


        /// <summary>
        /// 地图中的角色，以CharacterID为Key
        /// </summary>
        Dictionary<int, MapCharacter> MapCharacters = new Dictionary<int, MapCharacter>();

       

        /// <summary>
        /// 刷怪管理器
        /// </summary>
        SpawnManager SpawnManager = new SpawnManager();
        public MonsterManager MonsterManager = new MonsterManager();
        internal Map(MapDefine define)
        {
            this.Define = define;
            this.SpawnManager.Init(this);
            this.MonsterManager.Init(this);
        }

        internal void Update()
        {
            SpawnManager.Update();
        }

        /// <summary>
        /// 角色进入地图
        /// </summary>
        /// <param name="character"></param>
        internal void CharacterEnter(NetConnection<NetSession> conn, Character character)
        {
            Log.InfoFormat("CharacterEnter: Map:{0} characterId:{1}", this.Define.ID, character.Id);

            character.Info.mapId = this.ID;
            this.MapCharacters[character.Id] = new MapCharacter(conn,character);
            conn.Session.Response.mapCharacterEnter = new MapCharacterEnterResponse();
            conn.Session.Response.mapCharacterEnter.mapId = this.Define.ID;
            //NetMessage message = new NetMessage();
            //message.Response = new NetMessageResponse();

            //message.Response.mapCharacterEnter = new MapCharacterEnterResponse();
            //message.Response.mapCharacterEnter.mapId = this.Define.ID;
            //message.Response.mapCharacterEnter.Characters.Add(character.Info);

            foreach (var kv in this.MapCharacters)
            {
                conn.Session.Response.mapCharacterEnter.Characters.Add(kv.Value.character.Info);
                if (kv.Value.character!=character)
                {
                    this.AddCharacterEnterMap(kv.Value.connection,character.Info);
                }
                //message.Response.mapCharacterEnter.Characters.Add(kv.Value.character.Info);
                //this.SendCharacterEnterMap(kv.Value.connection, character.Info);
            }

            foreach (var kv in this.MonsterManager.Monsters)
            {
                conn.Session.Response.mapCharacterEnter.Characters.Add(kv.Value.Info);
            }
            //this.MapCharacters[character.entityId] = new MapCharacter(conn, character);

            //byte[] data = PackageHandler.PackMessage(message);
            // conn.SendData(data, 0, data.Length);
            conn.SendResponse();
        }

        //void SendCharacterEnterMap(NetConnection<NetSession> conn, NCharacterInfo character)
        //{
        //    NetMessage message = new NetMessage();
        //    message.Response = new NetMessageResponse();

        //    message.Response.mapCharacterEnter = new MapCharacterEnterResponse();
        //    message.Response.mapCharacterEnter.mapId = this.Define.ID;
        //    message.Response.mapCharacterEnter.Characters.Add(character);

        //    byte[] data = PackageHandler.PackMessage(message);
        //    conn.SendData(data, 0, data.Length);
        //}

        internal void CharacterLeave(Character cha)
        {
            Log.InfoFormat("CharacterLeave: Map:{0} characterId:{1}", this.Define.ID, cha.Id);           
            foreach (var kv in this.MapCharacters)
            {
                this.SendCharacterLeaveMap(kv.Value.connection,cha);
            }
            this.MapCharacters.Remove(cha.Id);
        }

        private void AddCharacterEnterMap(NetConnection<NetSession> conn, NCharacterInfo character)
        {
            if (conn.Session.Response.mapCharacterEnter==null)
            {
                conn.Session.Response.mapCharacterEnter = new MapCharacterEnterResponse();
                conn.Session.Response.mapCharacterEnter.mapId = this.Define.ID;
                
            }
            conn.Session.Response.mapCharacterEnter.Characters.Add(character);
            conn.SendResponse();
        }

        private void SendCharacterLeaveMap(NetConnection<NetSession> connection, Character cha)
        {
            connection.Session.Response.mapCharacterLeave = new MapCharacterLeaveResponse();
            connection.Session.Response.mapCharacterLeave.entityId = cha.entityId;
            connection.SendResponse();
            //NetMessage message = new NetMessage();
            //message.Response = new NetMessageResponse();
            //message.Response.mapCharacterLeave = new MapCharacterLeaveResponse();
            //message.Response.mapCharacterLeave.characterId = cha.Id;
            //byte[] data = PackageHandler.PackMessage(message);
            //connection.SendData(data, 0, data.Length);
        }
        internal void UpdateEntity(NEntitySync entitySync)
        {
            foreach (var kv in this.MapCharacters)
            {
                if (kv.Value.character.entityId==entitySync.Id)
                {
                    kv.Value.character.Position = entitySync.Entity.Position;
                    kv.Value.character.Direction = entitySync.Entity.Direction;
                    kv.Value.character.Speed = entitySync.Entity.Speed;
                }
                else
                {
                    MapService.Instance.SendEntityUpdate(kv.Value.connection,entitySync);
                }
            }
        }

        //地图怪物刷新（怪物进入地图）
        internal void MonsterEnter(Monster monster)
        {
            Log.InfoFormat("MonsterEnter: Map:{0} mossterId:{1}",this.Define.ID,monster.Id);
            foreach (var kv in this.MapCharacters)
            {
                this.AddCharacterEnterMap(kv.Value.connection, monster.Info);
            }
        }

       
    }
}

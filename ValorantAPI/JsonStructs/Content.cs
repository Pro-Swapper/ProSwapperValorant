using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.JsonStructs
{
    public class Character
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Map
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
        public string assetPath { get; set; }
    }

    public class Chroma
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Skin
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class SkinLevel
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Equip
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class GameMode
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
        public string assetPath { get; set; }
    }

    public class Spray
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class SprayLevel
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Charm
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class CharmLevel
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class PlayerCard
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class PlayerTitle
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Act
    {
        public string id { get; set; }
        public string parentId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
    }

    public class Ceremony
    {
        public string name { get; set; }
        public string id { get; set; }
        public string assetName { get; set; }
    }

    public class Content
    {
        public string version { get; set; }
        public List<Character> characters { get; set; }
        public List<Map> maps { get; set; }
        public List<Chroma> chromas { get; set; }
        public List<Skin> skins { get; set; }
        public List<SkinLevel> skinLevels { get; set; }
        public List<Equip> equips { get; set; }
        public List<GameMode> gameModes { get; set; }
        public List<Spray> sprays { get; set; }
        public List<SprayLevel> sprayLevels { get; set; }
        public List<Charm> charms { get; set; }
        public List<CharmLevel> charmLevels { get; set; }
        public List<PlayerCard> playerCards { get; set; }
        public List<PlayerTitle> playerTitles { get; set; }
        public List<Act> acts { get; set; }
        public List<Ceremony> ceremonies { get; set; }
    }


}

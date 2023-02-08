#nullable enable
using System.IO;
using Collections;
using Models;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public static class JsonStorage
    {
        private static readonly string GroupItemCollectionFilePath = Application.dataPath + "/GroupItemCollection.json";
        private static readonly string LevelItemCollectionFilePath = Application.dataPath + "/LevelItemCollection.json";
        public static void Save(GroupItemCollection groupItemCollectionCollection)
        {
            var jsonStr = JsonConvert.SerializeObject(groupItemCollectionCollection);
            if (!File.Exists(GroupItemCollectionFilePath))
            {
                using (File.Create(GroupItemCollectionFilePath))
                {
                }
            }
            File.WriteAllText(GroupItemCollectionFilePath, jsonStr);
        }
        public static void Save(LevelItemCollection levelItemCollection)
        {
            var jsonStr = JsonConvert.SerializeObject(levelItemCollection);
            if (!File.Exists(LevelItemCollectionFilePath))
            {
                using (File.Create(LevelItemCollectionFilePath))
                {
                }
            }

            File.WriteAllText(LevelItemCollectionFilePath, jsonStr);
        }

        public static GroupItemCollection? LoadGroupItemCollection()
        {
            if (!File.Exists(GroupItemCollectionFilePath))
            {
                using (File.Create(GroupItemCollectionFilePath))
                {
                }
            }

            using var streamReader = new StreamReader(GroupItemCollectionFilePath);
            var res = JsonConvert.DeserializeObject<GroupItemCollection>(streamReader.ReadToEnd());
            return res;
        }

        public static LevelItemCollection? LoadLevelItemCollection()
        {
            if (!File.Exists(LevelItemCollectionFilePath))
            {
                using (File.Create(LevelItemCollectionFilePath))
                {
                }
            }

            using var streamReader = new StreamReader(LevelItemCollectionFilePath);
            var res = JsonConvert.DeserializeObject<LevelItemCollection>(streamReader.ReadToEnd());
            return res;
        }
    }
}
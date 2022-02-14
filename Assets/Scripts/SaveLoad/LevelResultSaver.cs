using System.IO;
using UnityEngine;

namespace Testovoe3
{
    public static class LevelResultSaver
    {
        public static void Save(string resultName, LevelResult levelResult)
        {
            var filePath = Application.persistentDataPath + "/" + resultName;
            var text = JsonUtility.ToJson(levelResult);
            File.WriteAllText(filePath, text);
        }
    }
}
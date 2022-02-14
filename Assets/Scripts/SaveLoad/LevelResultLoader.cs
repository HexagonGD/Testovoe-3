using System.IO;
using UnityEngine;

namespace Testovoe3
{
    public static class LevelResultLoader
    {
        public static bool TryLoad(string resultName, out LevelResult levelResult)
        {
            var filePath = Application.persistentDataPath + "/" + resultName;
            levelResult = default;

            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);
                levelResult = JsonUtility.FromJson<LevelResult>(text);
                return true;
            }

            return false;
        }

        public static void Clear(string resultName)
        {
            var filePath = Application.persistentDataPath + "/" + resultName;

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
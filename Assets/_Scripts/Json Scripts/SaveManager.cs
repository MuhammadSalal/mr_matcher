using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace CyberSpeed.Matcher
{
    public static class SaveManager
    {

        static string presistantPath = Application.persistentDataPath + "saveFile.json";

        static SaveData _saveData;


        public static SaveData GetJsonFile()
        {
            //if (presistantPath == null)
            //    presistantPath = Application.persistentDataPath + "saveFile.json";

            //SaveData itemData;

            //string json = File.ReadAllText(presistantPath + "saveFile.json");
            //itemData = JsonUtility.FromJson<SaveData>(json);

            if (_saveData == null)
                InitlizeSaveFile();


            return _saveData;
        }

        public static void SaveFile(SaveData data)
        {
            //if (presistantPath == null)
            //   presistantPath = Application.persistentDataPath + "saveFile.json";


            _saveData = data;
            string json = JsonUtility.ToJson(_saveData);
            File.WriteAllText(presistantPath + "saveFile.json", json);

        }

        static void InitlizeSaveFile()
        {
            string json;


            try
            {

                // json = File.ReadAllText("Assets/Resources/saveFile.json");
                json = File.ReadAllText(presistantPath + "saveFile.json");
                _saveData = JsonUtility.FromJson<SaveData>(json);
                Debug.Log("file exists, location" + presistantPath);

            }
            catch
            {
                Debug.Log("File does not exist");


                _saveData = new SaveData();
                _saveData.Score = 0;
                _saveData.LevelsCompleted = 0;

                json = JsonUtility.ToJson(_saveData);
                File.WriteAllText(presistantPath + "saveFile.json", json);

            }

        }
    }
}

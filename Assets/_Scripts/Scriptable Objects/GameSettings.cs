using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{

    [CreateAssetMenu(menuName = "SO/Game Settings")]
    public class GameSettings : ScriptableObject
    {

        [Header("Note: Right click on GameSettings and select Reset Score to Reset the score")]
        [Space(10)]
        public int ScorePerCorrectMatch;



        [Header("Tween Settings")]
        public float InitialCardShowTime;
        public float CardFlipDuration;
        public float WrongCardShowDuration;


        [ContextMenu("Reset Score")]
        void ResetScre()
        {
            SaveData saveData = SaveManager.GetJsonFile();
            saveData.Score = 0;
            saveData.LevelsCompleted = 0;
            SaveManager.SaveFile(saveData);
        }
    }
}

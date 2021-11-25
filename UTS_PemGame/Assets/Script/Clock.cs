using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PG
{
    public class Clock : MonoBehaviour
    {
        private int time = 0;
        public Text timer;
        public Text highscore;
        public int timecurrent;
        void Start()
        {
            if (PlayerPrefs.HasKey("Highscore") == true)
            {
                highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
            }
            else
            {
                highscore.text = "No High Scores Yet";
            }
        }

        public void StartTimer()
        {
            time = 0;
            InvokeRepeating("IncrementTime", 1, 1);
        }

        public void StopTimer()
        {
            CancelInvoke();
            if (PlayerPrefs.GetInt("Highscore") < time)
            {
                SetHighscore();
            }

        }

        public void SetHighscore()
        {
            PlayerPrefs.SetInt("Highscore", time);
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }

        public void ClearHighscores()
        {
            PlayerPrefs.DeleteKey("Highscore");
            highscore.text = "No High Scores Yet";
        }

        void IncrementTime()
        {
            time += 1;
            timer.text = "Time: " + time;
        }

        public void currentTime()
        {
            timecurrent = time;
        }
        public void LoadCurrentTime()
        {
            time = timecurrent;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PG
{
    [System.Serializable]
    public class PlayerData
    {
        public int currentHealth; public float[] position;

        public PlayerData(PlayerStats playerStats)
        {
            currentHealth = playerStats.currentHealth;

            position = new float[3];
            position[0] = playerStats.transform.position.x;
            position[1] = playerStats.transform.position.y;
            position[2] = playerStats.transform.position.z;
        }
    }
}
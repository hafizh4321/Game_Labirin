using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

namespace PG
{
    public class DamagePlayer : MonoBehaviour
    {
        public int damage = 25;
        public CameraShake cameraShake;

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
                StartCoroutine(cameraShake.Shake(.15f, .4f));
            }
        }
    }
}
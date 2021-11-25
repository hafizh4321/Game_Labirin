using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PG
{
    public class Start : Interactable
    {
        public Clock clock;
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            Startgame(playerManager);
        }

        private void Startgame(PlayerManager playerManager)
        {
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;

            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();

            playerLocomotion.rigidbody.velocity = Vector3.zero;
            animatorHandler.PlayTargetAnimation("Pick Up Item", true);
            playerManager.itemInteractableGameObject.SetActive(true);
            Destroy(gameObject);
            clock.StartTimer();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PG
{
    public class Finish : Interactable
    {
        public Clock clock;
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            Stopgame(playerManager);
        }

        private void Stopgame(PlayerManager playerManager)
        {
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;

            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();

            playerLocomotion.rigidbody.velocity = Vector3.zero;
            animatorHandler.PlayTargetAnimation("Pick Up Item", true);
            playerManager.itemInteractableGameObject.SetActive(true);
            Destroy(gameObject);
            clock.StopTimer();
        }
    }
}
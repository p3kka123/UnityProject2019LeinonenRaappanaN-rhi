using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitboxHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.Instance.Stats.Health -= 10;
            print("player hp " + PlayerManager.Instance.Stats.Health);
            if(PlayerManager.Instance.Stats.Health <= 0)
            {
                Gamemanager.Instance.CurrentState = Gamemanager.GameState.Dead;
                Gamemanager.Instance.DeathScreen.FadeInDeathScreen();
                GetComponentInParent<AIScript>().PlayerDied();
                other.GetComponent<PlayerController>().Die();
            }
        }
    }
}

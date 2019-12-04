using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitboxHandler : MonoBehaviour
{

    private int thisEnemyDamage;

    private void Awake() {
        thisEnemyDamage = GetComponent<EnemyBase>().Damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerCombat>().TakeDamage(thisEnemyDamage);
            if(PlayerManager.Instance.Stats.CurrHealth <= 0)
            {
                Gamemanager.Instance.DeathScreen.FadeInDeathScreen();
                GetComponentInParent<EnemyAiScriptBase>().PlayerDied();
                other.GetComponent<PlayerController>().Die();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            DamageEnemy(other.gameObject);   
        }
    }

    private void DamageEnemy(GameObject target) {
        target.GetComponent<EnemyBase>().TakeDamage(CalculateDamage());
        print("Hit enemy: " + target + " with weapon: " + PlayerManager.Instance.PlayerEquipment.RightWeapon);
    }

    private int CalculateDamage() {
        PlayerManager mg = PlayerManager.Instance;
        Weapon weapon = mg.PlayerEquipment.RightWeapon as Weapon;

        return mg.Stats.Strength + weapon.Damage;
    }
}

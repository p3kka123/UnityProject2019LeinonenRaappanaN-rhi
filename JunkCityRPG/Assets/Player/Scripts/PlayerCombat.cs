using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private GameObject rightHandAnchorPoint;
    [SerializeField]
    private GameObject attackHitBox;


    private void Awake() {
        Gamemanager.Instance.AttackHitBox = attackHitBox;
        Gamemanager.Instance.PlayerRightHandAnchor = rightHandAnchorPoint;       
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            DamageEnemy(other.gameObject);   
        }
    }

    private void DamageEnemy(GameObject target) {
        target.GetComponent<EnemyBase>().TakeDamage(CalculateDamage());
        print("Hit enemy: " + target + " with weapon: " + PlayerManager.Instance.PlayerEquipment.EquipmentSlots[PlayerManager.Equipment.EquipmentSlot.RightHand]);
    }

    private int CalculateDamage() {
        PlayerManager mg = PlayerManager.Instance;
        Weapon weapon = mg.PlayerEquipment.EquipmentSlots[PlayerManager.Equipment.EquipmentSlot.RightHand] as Weapon;

        return mg.Stats.Strength + weapon.Damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            print(other.gameObject);
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(PlayerManager.Instance.Stats.GetStrength());
        }
    }
}

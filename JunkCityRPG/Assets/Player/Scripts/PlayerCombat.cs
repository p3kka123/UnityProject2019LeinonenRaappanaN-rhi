using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = new PlayerStats(10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            print(other.gameObject);
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(stats.GetStrength());
        }
    }
}

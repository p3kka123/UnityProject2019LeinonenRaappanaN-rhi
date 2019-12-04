using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private float health;
    [SerializeField]
    private int exp;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(20, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0) {
            Destroy(this.gameObject);
            PlayerManager.Instance.Stats.GainExp(exp);
            //GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10,50),Random.Range(10,50),Random.Range(10,50)));
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
    }

}

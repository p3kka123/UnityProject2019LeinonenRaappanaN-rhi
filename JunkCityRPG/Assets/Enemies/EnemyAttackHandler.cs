using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [SerializeField]
    private BoxCollider AttHitbox;

    public void HandleAttack()
    {
        AttHitbox.gameObject.SetActive(!AttHitbox.gameObject.activeSelf);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCollider : MonoBehaviour
{
    EnemyBaseController _enemyBase;
    private void Start()
    {
        _enemyBase= GetComponent<EnemyBaseController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FriendlyMob"))
        {
            _enemyBase.count--;
        }
    }
}

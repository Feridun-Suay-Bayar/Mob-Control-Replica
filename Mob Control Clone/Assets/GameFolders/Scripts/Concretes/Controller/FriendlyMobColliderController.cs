using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyMobColliderController : MonoBehaviour
{
    bool _onLayerEnter;
    public bool OnLayerEnter => _onLayerEnter;
    private void OnEnable()
    {
        _onLayerEnter = false;
    }
    private void OnDisable()
    {
        _onLayerEnter = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyLayer"))
        {
            _onLayerEnter = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBase"))
        {
            ObjectPooling.Instance.SetPoolObject(transform.gameObject, 0);
        }
    }
}

using PlayerMove.Controllers;
using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendlyMobColliderController : MonoBehaviour
{
    [SerializeField] MobSO _mobSO;

    bool _destroy;
    bool _onLayerEnter;
    int _currentHealth;
    public bool OnLayerEnter => _onLayerEnter;
    public bool Destroy => _destroy;

    private void Start()
    {
        _currentHealth = _mobSO.maxHealth;
    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one; 
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
        if (other.gameObject.CompareTag("EnemyBase"))
        {
            ObjectPooling.Instance.SetPoolObject(transform.gameObject, 0);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyMob"))
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                _destroy = true;
            }
            else
            {
                Vector3 scale = gameObject.transform.localScale;
                scale -= new Vector3(0.25f, 0.25f, 0.25f);
                gameObject.transform.localScale = scale;
            }
        }
    }
}

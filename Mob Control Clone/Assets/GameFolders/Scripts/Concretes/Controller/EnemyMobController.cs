using PlayerMove.Movements;
using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class EnemyMobController : MonoBehaviour
    {
        [SerializeField] MobSO _mobSO;

        [SerializeField] Transform _enemyBase;
        [SerializeField] float _speed;
        MobMover _mobMover;

        int _currentHealth;

        // Start is called before the first frame update
        void Start()
        {
            _currentHealth = _mobSO.maxHealth;
            _mobMover = new MobMover(transform);
        }
        // Update is called once per frame
        void Update()
        {
            _mobMover.MoveToLine(_speed, _enemyBase, Vector3.up *180);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("FriendlyMob"))
            {
                _currentHealth--;
                if (_currentHealth == 0)
                {
                    ObjectPooling.Instance.SetPoolObject(transform.gameObject, _mobSO.type - 1);
                }
                else
                {
                    Vector3 scale = gameObject.transform.localScale;
                    scale -= new Vector3(0.25f, 0.25f, 0.25f);
                    gameObject.transform.localScale = scale;
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Line"))
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
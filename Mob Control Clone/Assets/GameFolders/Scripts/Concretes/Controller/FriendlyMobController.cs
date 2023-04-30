using PlayerMove.Movements;
using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class FriendlyMobController : MonoBehaviour
    {
        [SerializeField] MobSO _mobSO;
        [SerializeField] float _speed;
        
        GameObject _enemyBase;

        MobMover _mobMover;
        FriendlyMobColliderController _mobColliderController;

        public float Speed => _speed;
        public MobSO MobSO => _mobSO;
        public bool IsDuplicated;

        void Start()
        {
            _enemyBase = GameObject.Find("EnemyBase");
            _mobMover = new MobMover(transform);
            _mobColliderController = GetComponent<FriendlyMobColliderController>();
        }

        void Update()
        {
            if (!_mobColliderController.OnLayerEnter)
            {
                _mobMover.MoveToLine(_speed, _enemyBase.transform,Vector3.zero);
            }
            else
            {
                _mobMover.MoveToDirection(_speed, _enemyBase.transform);
            }
            if (IsDuplicated)
            {
                StartCoroutine(MakeDuplicadeable());
            }
            if (_mobColliderController.Destroy)
            { 
                ObjectPooling.Instance.SetPoolObject(transform.gameObject, _mobSO.type-1);
                //Debug.Log(_particle.gameObject.name);
                //StartCoroutine(DestroyObject());
            }
        }
        private IEnumerator MakeDuplicadeable()
        {
            yield return new WaitForSeconds(0.75f);
            IsDuplicated = false;
        }
        private IEnumerator DestroyObject()
        {
            yield return new WaitForSeconds(0.5f);
            ObjectPooling.Instance.SetPoolObject(transform.gameObject, _mobSO.type-1);
        }
    }
}
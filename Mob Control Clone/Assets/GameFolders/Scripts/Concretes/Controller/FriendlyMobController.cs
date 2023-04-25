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

        public MobSO MobSO => _mobSO;
        public bool IsDuplicated;
        // Start is called before the first frame update
        void Start()
        {
            _enemyBase = GameObject.Find("EnemyBase");
            _mobMover = new MobMover(transform);
            _mobColliderController = GetComponent<FriendlyMobColliderController>();
        }

        // Update is called once per frame
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
        }
        private IEnumerator MakeDuplicadeable()
        {
            yield return new WaitForSeconds(0.75f);
            IsDuplicated = false;
        }

    }
}
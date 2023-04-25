using PlayerMove.Movements;
using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class EnemyMobController : MonoBehaviour
    {
        [SerializeField] Transform _enemyBase;
        [SerializeField] float _speed;
        MobMover _mobMover;
        // Start is called before the first frame update
        void Start()
        {
            _mobMover = new MobMover(transform);
        }

        // Update is called once per frame
        void Update()
        {
            _mobMover.MoveToLine(_speed, _enemyBase, Vector3.up *180);
        }
    }
}
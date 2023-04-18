using PlayerMove.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] GameObject _enemyBase;

    MobMover _mobMover;
    FriendlyMobColliderController _mobColliderController;
    // Start is called before the first frame update
    void Start()
    {
        _enemyBase = GameObject.Find("EnemyBase");
        _mobMover = new MobMover(this.transform);
        _mobColliderController = GetComponent<FriendlyMobColliderController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_mobColliderController.OnLayerEnter)
        {
            _mobMover.MoveToLine(_speed, _enemyBase.transform);
        }
        else
        {
            _mobMover.MoveToDirection(_speed, _enemyBase.transform);
        }
    }
    
}

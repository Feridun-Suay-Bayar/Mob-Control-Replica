using PlayerMove.Movements;
using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] MobSO _mobSO;
    [SerializeField] float _speed;
    [SerializeField] GameObject _enemyBase;

    MobMover _mobMover;
    FriendlyMobColliderController _mobColliderController;

    public MobSO MobSO => _mobSO;
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
        if (_mobSO.isDuplicated)
        {
            Debug.Log("wasdasdasd");
            StartCoroutine(MakeDuplicadeable());
        }
    }
    private IEnumerator MakeDuplicadeable()
    {
        yield return new WaitForSeconds(0.75f);
        _mobSO.isDuplicated = false;
    }
    
}

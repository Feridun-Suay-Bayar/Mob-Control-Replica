using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    Transform _transform;

    public SpawnController(Transform transform)
    {
        _transform = transform;
    }
    public void SpawnFriendMob()
    {
        var gameObject = ObjectPooling.Instance.GetPoolObject(0);
        gameObject.SetActive(true);
        gameObject.transform.rotation= Quaternion.identity;
        gameObject.transform.position = _transform.position;
    }
}

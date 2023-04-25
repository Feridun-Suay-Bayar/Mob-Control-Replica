using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        Transform _transform;

        private int _maxCount;
        private int _strongFriendCount;

        public int StrongFriendCount => _strongFriendCount;
        public SpawnController(Transform transform, int maxCount)
        {
            _transform = transform;
            _maxCount = maxCount;
            _strongFriendCount = 0;
        }
        public void SpawnFriendMob()
        {
            if (_strongFriendCount != _maxCount)
            {
                FriendMobSet(0);
                _strongFriendCount++;
            }
            else
            {
                FriendMobSet(1);
                _strongFriendCount = 0;
            }
        }
        void FriendMobSet(int type)
        {
            var gameObject = ObjectPooling.Instance.GetPoolObject(type);
            gameObject.SetActive(true);
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.position = _transform.position;
        }
    }
}
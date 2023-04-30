using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] Transform _spawnPoint;
        
        public void SpawnEnemies(int index)
        {
            GameObject gameObject = ObjectPooling.Instance.GetPoolObject(index);
            gameObject.transform.position = _spawnPoint.position;
        }
    }
}
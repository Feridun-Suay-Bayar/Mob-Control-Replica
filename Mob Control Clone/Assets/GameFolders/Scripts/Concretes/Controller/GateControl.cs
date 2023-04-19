using PlayerMove.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class GateControl : MonoBehaviour
    {
        [SerializeField] GateSO _gateSo;
        MobSO _mobSO;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("FriendlyMob"))
            {
                _mobSO = other.GetComponent<MobController>().MobSO;
                if (_mobSO.isDuplicated) return;
                _mobSO.isDuplicated = true;
                int var = _gateSo.count;
                for(int i=1; i<var; i++)
                {
                    var newObject = ObjectPooling.Instance.GetPoolObject(_mobSO.type - 1);
                    newObject.transform.position = other.gameObject.transform.position + new Vector3(0.75f,0,0);
                    newObject.GetComponent<MobController>().MobSO.isDuplicated = true;
                }
            }
        }
    }
}
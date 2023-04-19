using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Scriptables
{
    [CreateAssetMenu(fileName = "New Gate SO", menuName = "New Scriptable Objects/Create/Gate", order = 50)]
    public class GateSO : ScriptableObject
    {
        public int count;
    }
}
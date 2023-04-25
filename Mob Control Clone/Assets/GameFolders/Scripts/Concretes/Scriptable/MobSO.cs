using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Scriptables
{
    [CreateAssetMenu(fileName = "New Mob SO", menuName = "New Scriptable Objects/Create/Mob", order = 50)]
    public class MobSO : ScriptableObject
    {
        public int type;
        public int maxHealth;
    }
}

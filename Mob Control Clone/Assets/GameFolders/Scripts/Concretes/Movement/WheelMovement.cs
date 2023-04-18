using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Movements
{
    public class WheelMovement : MonoBehaviour
    {
        private Transform _transform;

        public WheelMovement(Transform transform)
        {
            _transform = transform;
        }
        
        public void RotateWheel(float speed)
        {
            _transform.Rotate(0,speed * Time.deltaTime,0);
           
        }
    }
}
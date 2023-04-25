using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Movements
{
    public class MobMover : MonoBehaviour
    {
        Transform _transform;
        Vector3 _direction;
        public MobMover(Transform transform)
        {
            _transform = transform;
        }
        public void MoveToDirection( float speed, Transform transform)
        {
            _direction = transform.position - _transform.position;
            _direction = new Vector3(_direction.x, 0, _direction.z);
            _direction = _direction.normalized;
            _transform.Translate(_direction * Time.deltaTime * speed,Space.World);
        }
        public void MoveToLine(float speed, Transform transform, Vector3 lookDirection)
        {
            _direction = transform.position - _transform.position;
            _direction = new Vector3(0, 0, _direction.z);
            _direction = _direction.normalized;
            _transform.Translate(_direction * Time.deltaTime * speed, Space.World);
            _transform.rotation = Quaternion.Euler(lookDirection);
        }
        
    }
}
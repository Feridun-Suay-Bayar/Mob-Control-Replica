using PlayerMove.Abstracts.Inputs;
using PlayerMove.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class WheelsController : MonoBehaviour
    {
        [SerializeField] float _wheelSpeed;

        IInput _input;
        WheelMovement _wheelMovement;
        void Start()
        {
            _input= GetComponentInParent<IInput>();
            _wheelMovement = new WheelMovement(transform);
        }


        void Update()
        {
            if (_input.Direction.magnitude == 0) return;

            else
            {
                _wheelMovement.RotateWheel(_wheelSpeed * _input.Direction.normalized.x);
            }
        }
    }
}
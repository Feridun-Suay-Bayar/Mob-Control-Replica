using PlayerMove.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Animations
{
    public class PlayerAnimationController : MonoBehaviour
    {
        Animator _anim;
        // Start is called before the first frame update
        void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void Shoot()
        {
            _anim.SetTrigger("Shoot");
        }
    }
}
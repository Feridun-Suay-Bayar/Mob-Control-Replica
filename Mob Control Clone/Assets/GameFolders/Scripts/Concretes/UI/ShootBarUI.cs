using PlayerMove.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerMove.UI
{
    public class ShootBarUI : MonoBehaviour
    {
        [SerializeField] Image _bar; 
        ShootController _shootController;

        private void Start()
        {
            _shootController = GetComponent<ShootController>();
        }
        private void Update()
        { 
            _bar.fillAmount = (float)_shootController.FriendCount/15;
        }
    }
}
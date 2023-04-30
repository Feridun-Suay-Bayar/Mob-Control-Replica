using PlayerMove.Abstracts.Inputs;
using PlayerMove.Animations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMove.Controllers
{
    public class ShootController : MonoBehaviour
    {

        [SerializeField] float _maxShootDelay = 0.5f;
        [SerializeField] Transform _shootPoint;
        [SerializeField] int _strongFriendMaxCount = 15;
        private float _currentDelay;
        public int FriendCount => _spawnController.StrongFriendCount;

        IInput _input;
        PlayerAnimationController _animationController;
        SpawnController _spawnController;

        private void Start()
        {
            _input = GetComponent<IInput>();
            _animationController = GetComponentInChildren<PlayerAnimationController>();
            _spawnController = new SpawnController(_shootPoint, _strongFriendMaxCount);  
        }

        void Update()
        {
            _currentDelay += Time.deltaTime;
            if (!_input.Pressed) return;
            if (_currentDelay < _maxShootDelay) return;
            else
            {
                _currentDelay = 0;
                _animationController.Shoot();
                _spawnController.SpawnFriendMob();
            }
        }
    }
}
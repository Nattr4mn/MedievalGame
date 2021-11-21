using MedievalGame.Model;
using UnityEngine;

namespace MedievalGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Movement Movement => _playerMovement;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        private Movement _playerMovement;

        private void Awake()
        {
            _playerMovement = new Movement(_moveSpeed, _rotationSpeed);
        }
    }
}

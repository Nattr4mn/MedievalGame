using MedievalGame.Model;
using System.Collections;
using UnityEngine;

namespace MedievalGame.Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private AudioSource _stepSource;
        private bool _isLocked = false;
        private bool _isStep = false;

        public void Control(Movement playerMovement)
        {
            if (InputUI.Instance.Joystick.Vertical != 0 && !_isLocked)
            {
                _animator.SetBool("isRunning", true);
                _rigidbody.velocity = playerMovement.Move(_playerObject.transform.forward) * Time.deltaTime;

                PlayerRotate(playerMovement);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }

        public void Collecting()
        {
            _isLocked = true;
            InputUI.Instance.Action -= Collecting;
            StartCoroutine(CollectingCoroutine("gathering"));
        }

        public void PickUp()
        {
            _isLocked = true;
            InputUI.Instance.Action -= PickUp;
            StartCoroutine(CollectingCoroutine("pickup"));
        }

        private void PlayerRotate(Movement playerMovement)
        {
            if (InputUI.Instance.Joystick.Vertical > 0)
                _playerObject.transform.rotation = playerMovement.Rotate(_playerObject.transform.rotation, 90f * InputUI.Instance.Joystick.Horizontal);
            else if (InputUI.Instance.Joystick.Vertical < 0)
                _playerObject.transform.rotation = playerMovement.Rotate(_playerObject.transform.rotation, 180f + (-90f) * InputUI.Instance.Joystick.Horizontal);

        }

        private IEnumerator CollectingCoroutine(string animationName)
        {
            _animator.SetTrigger(animationName);
            yield return new WaitForSeconds(3f);
            _isLocked = false;
        }
    }
}

using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private float playerSpeed;
    private Rigidbody _playerRB;
    private Animator _animator;

    public void Init(float playerSpeed, Rigidbody playerRB, Animator animator)
    {
        this.playerSpeed = playerSpeed;
        this._playerRB = playerRB;
        this._animator = animator;
    }

    public void PlayerMove()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.TransformDirection(Vector3.forward);
        _animator.SetBool("idle", false);
        _animator.SetBool("run", true);

        _playerRB.velocity = direction * playerSpeed * Time.deltaTime;
    }

    public void PlayerRotate(float rotationY)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z), 12f * Time.deltaTime);
    }
}

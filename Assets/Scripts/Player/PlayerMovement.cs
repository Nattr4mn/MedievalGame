using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _playerSpeed;
    private Rigidbody _playerRB;

    public void Init(float playerSpeed, Rigidbody playerRB)
    {
        _playerSpeed = playerSpeed;
        _playerRB = playerRB;
    }

    public void PlayerMove()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.TransformDirection(Vector3.forward);
        _playerRB.velocity = direction * _playerSpeed * Time.deltaTime;
    }

    public void PlayerRotate(float rotationY)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z), 10f * Time.deltaTime);
    }
}

using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed;
    private Rigidbody _rigidbody;

    public void Init(float playerSpeed, Rigidbody playerRB)
    {
        _speed = playerSpeed;
        _rigidbody = playerRB;
    }

    public void Move()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.TransformDirection(Vector3.forward);
        _rigidbody.velocity = direction * _speed * Time.deltaTime;
    }

    public void Rotate(float rotationY)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z), 10f * Time.deltaTime);
    }
}

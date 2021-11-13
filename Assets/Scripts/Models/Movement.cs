using UnityEngine;

namespace MedievalGame.Model
{
    public class Movement
    {
        private float _moveSpeed;
        private float _rotationSpeed;

        public Movement(float moveSpeed, float rotationSpeed)
        {
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
        }

        public Vector3 Move(Vector3 forward)
        {
            forward *= _moveSpeed;

            return forward;
        }

        public Quaternion Rotate(Quaternion sourceRotation, float requiredRotationY)
        {
            return Quaternion.Lerp(sourceRotation, Quaternion.Euler(sourceRotation.x, requiredRotationY, sourceRotation.z), _rotationSpeed * Time.deltaTime);
        }
    }
}

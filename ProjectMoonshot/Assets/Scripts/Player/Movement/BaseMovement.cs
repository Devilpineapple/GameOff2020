using UnityEngine;

namespace Player.Movement
{
    public class BaseMovement
    {
        public InputActions inputActions;

        public Vector2 direction;

        protected float Speed { get; }
        private Transform Character;

        protected BaseMovement(float speed, Transform character)
        {
            inputActions = new InputActions();
            Speed = speed;
            Character = character;
        }

        public virtual Vector3 Direction()
        {
            return Vector3.zero;
        }

        public void FaceDirection()
        {
            if (direction != Vector2.zero)
                Character.rotation = Quaternion.Slerp(Character.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y)), 0.2f);
        }
    }
}
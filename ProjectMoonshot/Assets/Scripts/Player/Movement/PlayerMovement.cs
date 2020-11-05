using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : BaseMovement
    {
        private readonly bool _isPlayerTwo;
        public PlayerMovement(float speed, Transform character, bool isPlayerTwo) : base(speed, character)
        {
            _isPlayerTwo = isPlayerTwo;
            if (_isPlayerTwo)
                inputActions.Player.P2Move.Enable();
            else
                inputActions.Player.P2Move.Disable();
        }

        public override Vector3 Direction()
        {
            direction = _isPlayerTwo ? inputActions.Player.P2Move.ReadValue<Vector2>() : inputActions.Player.P1Move.ReadValue<Vector2>();
            return new Vector3(direction.x, 0f, direction.y) * Speed;
        }
    }
}
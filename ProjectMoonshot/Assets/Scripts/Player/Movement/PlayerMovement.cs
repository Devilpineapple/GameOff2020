using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    public class PlayerMovement : BaseMovement
    {
        private readonly bool _isPlayerTwo;

        public PlayerMovement(float speed, Transform character, bool isPlayerTwo) : base(speed, character)
        {
            _isPlayerTwo = isPlayerTwo;
            if (_isPlayerTwo)
                inputActions.PlayerTwo.Enable();
            else
                inputActions.PlayerTwo.Disable();
        }

        public override Vector3 Direction()
        {
            direction = _isPlayerTwo ? inputActions.PlayerTwo.Move.ReadValue<Vector2>() : inputActions.PlayerOne.Move.ReadValue<Vector2>();
            return new Vector3(direction.x, 0f, direction.y) * Speed;
        }

        public override void ToggleCraftingTable(UnityEvent @event)
        {
            if (!isOnCraftingTable) return;
            var clicked = _isPlayerTwo ? inputActions.PlayerTwo.Action.triggered : inputActions.PlayerOne.Action.triggered;
            if (clicked)
                base.ToggleCraftingTable(@event);
        }

        public override void PickUpItem()
        {
            if (!pickable.available) return;
            var clicked = _isPlayerTwo ? inputActions.PlayerTwo.Action.triggered : inputActions.PlayerOne.Action.triggered;
            if (clicked)
                Debug.Log("Pick up -> " + pickable.item.name);
        }
    }
}
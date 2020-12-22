using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    public class BaseMovement
    {
        public InputActions inputActions;
        public Vector2 direction;
        public Pickable pickable;
        public bool isOnCraftingTable;
        
        public struct Pickable
        {
            public bool available;
            public GameObject item;

            public void Set(bool isAvailable, GameObject newItem)
            {
                available = isAvailable;
                item = newItem;
            }
        }
        
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

        public virtual void PickUpItem()
        {
            Debug.Log("Pick up item");
        }
        
        public virtual void ToggleCraftingTable(UnityEvent @event)
        {
            @event?.Invoke();
        }

        public void FaceDirection()
        {
            if (direction != Vector2.zero)
                Character.rotation = Quaternion.Slerp(Character.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y)), 0.2f);
        }
    }
}
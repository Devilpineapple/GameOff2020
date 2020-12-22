using Player.Movement;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public enum PlayerType { PlayerOne, PlayerTwo, AI }

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public Transform character;
        public PlayerType playerType;
        public UnityEvent onCraftingTable = new UnityEvent();

        private BaseMovement _movement;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            switch (playerType)
            {
                case PlayerType.PlayerOne:
                    _movement = new PlayerMovement(speed, character, false);
                    break;
                case PlayerType.PlayerTwo:
                    _movement = new PlayerMovement(speed, character, true);
                    break;
                case PlayerType.AI:
                    _movement = new AIMovement(speed, character);
                    break;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Item"))
                _movement.pickable.Set(true, other.gameObject);
            if (other.CompareTag("CraftingTable"))
                _movement.isOnCraftingTable = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
                _movement.pickable.Set(true, other.gameObject);
            if (other.CompareTag("CraftingTable"))
                _movement.isOnCraftingTable = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Item"))
                _movement.pickable.Set(false, other.gameObject);
            if (other.CompareTag("CraftingTable"))
                _movement.isOnCraftingTable = false;
        }

        private void OnDisable() => _movement.inputActions.Disable();

        private void OnEnable() => _movement.inputActions.Enable();

        private void Update()
        {
            _movement.ToggleCraftingTable(onCraftingTable);
            _movement.PickUpItem();
            _movement.FaceDirection();
            _rigidbody.MovePosition(transform.position + _movement.Direction() * Time.deltaTime);
        }
    }
}
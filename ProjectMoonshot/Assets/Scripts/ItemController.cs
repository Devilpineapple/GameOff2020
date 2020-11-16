using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        _rigidbody.velocity = transform.forward * 5f;
        Physics.IgnoreLayerCollision(8, 9);
    }
}
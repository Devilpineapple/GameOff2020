using DG.Tweening;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject item;
    private Rigidbody _rb;

    #region Events

    private void Awake() => _rb = GetComponent<Rigidbody>();

    private void Start()
    {
        item.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
        _rb.velocity = transform.forward * 5f;
        Physics.IgnoreLayerCollision(8, 9);
    }
    
    #endregion
}
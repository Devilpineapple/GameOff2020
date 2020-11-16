using UnityEngine;

namespace Platform
{
    public class Trash : BasePlatform
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
                Destroy(other.gameObject);
        }
    }
}
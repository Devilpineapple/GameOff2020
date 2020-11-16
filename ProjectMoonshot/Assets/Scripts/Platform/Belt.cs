using UnityEngine;

namespace Platform
{
    public class Belt : MonoBehaviour
    {
        public float speed;
        public float exitSpeed;
        
        private static void TriggerItem(Component col, float speedTime)
        {
            if (col.CompareTag("Item"))
                col.GetComponent<Rigidbody>().velocity = col.transform.forward * speedTime;
        }

        #region Triggers

        private void OnTriggerEnter(Collider other) => TriggerItem(other, speed);

        private void OnTriggerStay(Collider other) => TriggerItem(other, speed);

        private void OnTriggerExit(Collider other) => TriggerItem(other, exitSpeed);

        #endregion
    }
}
using UnityEngine;

namespace Platform
{
    public class BasePlatform : MonoBehaviour
    {
        // public enum Type { Trash, Dispenser, ConveyorBelt, Wall, Ground }

        // public Type type;

        public virtual void Action()
        {
            Debug.Log("Do Action");
        }
    }
}
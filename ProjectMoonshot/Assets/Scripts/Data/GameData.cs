using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Data/Game Settings")]
    public class GameData : ScriptableObject
    {
        public float startCooldown;
    }
}
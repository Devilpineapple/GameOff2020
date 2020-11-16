using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Level Settings", menuName = "Data/Level Settings")]
    public class LevelData : ScriptableObject
    {
        [Serializable]
        public struct Level
        {
            public GameObject level;
            public int width, height;
            
        }
    }
}
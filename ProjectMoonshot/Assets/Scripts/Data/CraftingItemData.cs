using System;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    [CreateAssetMenu(fileName = "New Crafting Items Settings", menuName = "Data/Crafting Items Settings")]
    public class CraftingItemData : ScriptableObject
    {
        [Serializable]
        public struct Item
        {
            public string name;
            public GameObject prefab;
            public Image image;
            public GameObject[] ingredients;
            public bool crafted;
        }

        public Item[] craftingItems;
    }
}
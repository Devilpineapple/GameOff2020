using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Map Settings", menuName = "Data/Map Settings")]
    public class MapData : ScriptableObject
    {
        [Serializable]
        public struct Map
        {
            [Serializable]
            public struct Dimension
            {
                public float height;
                public float width;
            }
        
            [Serializable]
            public struct Tile
            {
                public GameObject prefab;
                public float size;
            }

            public Dimension dimension;
            public Tile tile;
            public Tile wall;
            public Tile conveyorBelt;
            public Tile voidPlatform;
            public Tile dispenser;
            public float buildSpeed;
        }

        public Map mapData;

        public void Help()
        {
            Debug.Log("Map Dimension -> " + mapData.dimension.height + " , " + mapData.dimension.width);
            Debug.Log("Map tile -> " + mapData.tile.prefab.name + " - " + mapData.tile.size);
            Debug.Log("Map build speed -> " + mapData.buildSpeed);
        }
    }
}
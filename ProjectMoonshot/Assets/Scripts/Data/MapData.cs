using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Map Settings", menuName = "Data/Map Settings")]
    public class MapData : ScriptableObject
    {
        // public enum TileType { Trash, Dispenser, ConveyorBelt, Wall, Ground }

        #region Dimension
        
        /// <summary>
        /// Contains the Grid's dimension
        /// </summary>
        [Serializable]
        public struct Dimension
        {
            public int height, width;
            
            public void Help()
            {
                for (var x = 0; x < height; x++)
                {
                    var str = "";
                    for (var y = 0; y < width; y++)
                    {
                        if (x == 0 && y == width - 1)
                            str += "T";
                        else if (x == height - 1 && y == width - 1)
                            str += "D";
                        else if (y == 0 || x == 0 || x == height)
                            str += "W";
                        else if (y == width - 1)
                            str += "C";
                        else
                            str += "G";
                    }
                    str += "\n";
                    Debug.Log(str);
                }
            }

            public void Scan(Tiles tiles, in GameObject[,] array)
            {
                for (var x = 0; x < height; x++)
                {
                    for (var y = 0; y < width; y++)
                    {
                        if (x == 0 && y == width - 1)
                            array[x, y] = tiles.types[0];
                        else if (x == height - 1 && y == width - 1)
                            array[x, y] = tiles.types[1];
                        else if (y == 0 || x == 0 || x == height - 1)
                            array[x, y] = tiles.types[3];
                        else if (y == width - 1)
                            array[x, y] = tiles.types[2];
                        else
                            array[x, y] = tiles.types[4];
                    }
                }
            }
        }

        #endregion

        #region Tiles

        [Serializable]
        public class Tiles
        {
            public List<GameObject> types;
            public GameObject[,] array;
            public float size;
        }

        #endregion
        
        [Serializable]
        public struct Map
        {
            public enum BuildType { OneByOne, RowByRow }

            public Dimension dimension;
            public Tiles tiles;
            public float buildSpeed;
            public BuildType buildType;

            public void Setup()
            {
                tiles.array = new GameObject[dimension.height, dimension.width];
                dimension.Scan(tiles, tiles.array);
            }
        }

        public Map mapData;
    }
}
using System.Collections.Generic;
using Data;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Absolute
{
    public class SectionController : MonoBehaviour
    {
        public Camera cam;
        public Transform terrain;
        public List<GameObject> platforms = new List<GameObject>();
        public PlayerController player;
        public Vector3 offset;

        public void Setup(MapData.Dimension dimension, float x)
        {
            SetCamera(dimension, x);
            SetTerrainCenter(dimension);
        }
    
        public void Setup(MapData.Dimension dimension)
        {
            SetTerrainCenter(dimension);
        }

        public void MoveCamera(float fov, Vector2 position, float duration, TweenCallback callback = null)
        {
            cam.fieldOfView = fov;
            cam.transform.DOMove(new Vector3(position.x, cam.transform.localPosition.y, position.y), duration).OnComplete(callback);
        }

        public void EnablePlayer()
        {
            var position = terrain.position;
            player.transform.position = new Vector3(position.x + offset.x, (position.y + 1) + offset.y, position.z + offset.z);
            player.gameObject.SetActive(true);
        }

        private void SetCamera(MapData.Dimension dimension, float x)
        {
            cam.transform.localPosition = new Vector3(dimension.width / 2, dimension.height, -dimension.height / 2);
        }

        private void SetTerrainCenter(MapData.Dimension dimension) => terrain.localPosition = new Vector3(-transform.position.x / 2, 0f, -dimension.height / 4);
    }
}

using System;
using System.Collections.Generic;
using Data;
using DG.Tweening;
using Player;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public Camera cam;
    public Transform terrain;
    public List<GameObject> tiles = new List<GameObject>();
    public PlayerController player;

    private Rect originCamRect;

    private void Awake()
    {
        originCamRect = cam.rect;
    }

    public void Setup(MapData.Map.Dimension dimension, float x)
    {
        SetCamera(dimension, x);
        SetTerrainCenter(dimension);
    }

    public void MoveCamera(float fov, Vector2 position, float duration, TweenCallback callback = null)
    {
        cam.fieldOfView = fov;
        cam.transform.DOMove(new Vector3(position.x, cam.transform.localPosition.y, position.y), duration).OnComplete(callback);
    }

    public void ShowCamera(TweenCallback callback)
    {
        cam.DORect(originCamRect, 0).OnComplete(callback);
    }
    
    private void SetCamera(MapData.Map.Dimension dimension, float x)
    {
        // cam.GetComponent<CameraController>().minXPosition = -(dimension.width / 7.5f);
        // cam.GetComponent<CameraController>().maxXPosition = (dimension.width / 5);
        cam.DORect(new Rect(x, 0, 1f, 1f), 0f);
        cam.transform.localPosition = new Vector3(dimension.width / 2, cam.transform.position.y, -dimension.height / 2);
    }

    private void SetTerrainCenter(MapData.Map.Dimension dimension) => terrain.localPosition = new Vector3(dimension.width / 2, 0f, -dimension.height / 2);
}

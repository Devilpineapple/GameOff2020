using System.Collections.Generic;
using Data;
using DG.Tweening;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public Camera cam;
    public Transform terrain;
    public List<GameObject> tiles = new List<GameObject>();
    public GameObject player;

    public void Setup(MapData.Map.Dimension dimension)
    {
        SetCamera(dimension);
        SetTerrainCenter(dimension);
        // cam.DO
    }
    
    private void SetCamera(MapData.Map.Dimension dimension) => cam.transform.localPosition = new Vector3(dimension.width / 2, cam.transform.position.y, -dimension.height / 2);

    private void SetTerrainCenter(MapData.Map.Dimension dimension) => terrain.localPosition = new Vector3(dimension.width / 2, 0f, -dimension.height / 2);
}

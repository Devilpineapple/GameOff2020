using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Settings")] public MapData settings;
    [Header("Team A")] public SectionController teamA;
    [Header("Team B")] public SectionController teamB;

    private void Awake()
    {
        teamA.Setup(settings.mapData.dimension);
        teamB.Setup(settings.mapData.dimension);
        StartCoroutine(BuildGrid(teamA.transform, teamA.terrain, teamA.tiles, teamA.player));
        StartCoroutine(BuildGrid(teamB.transform, teamB.terrain, teamB.tiles, teamB.player));
    }

    private GameObject LoadTile(GameObject tile, Transform parent, Vector3 position)
    {
        var instance = Instantiate(tile, position, Quaternion.identity, parent);
        instance.transform.localScale = new Vector3(settings.mapData.tile.size, settings.mapData.tile.size, settings.mapData.tile.size);
        return instance;
    }

    private IEnumerator BuildGrid(Transform center, Transform parent, List<GameObject> tiles, GameObject player)
    {
        var cPosition = center.position;
        for (var i = 0; i < settings.mapData.dimension.height; i++)
        {
            cPosition.z--;
            for (var o = 0; o < settings.mapData.dimension.width; o++)
            {
                cPosition.x++;
                GameObject tile;
                if (i == 0 && o == settings.mapData.dimension.width - 1)
                {
                    tile = LoadTile(settings.mapData.voidPlatform.prefab, center, cPosition);
                }
                else if (i == settings.mapData.dimension.height - 1 && o == settings.mapData.dimension.width - 1)
                {
                    tile = LoadTile(settings.mapData.dispenser.prefab, center, cPosition);
                }
                else if (o == 0 || i == 0 || i == settings.mapData.dimension.height - 1)
                {
                    tile = LoadTile(settings.mapData.wall.prefab, center, cPosition);
                }
                else if (o == settings.mapData.dimension.width - 1)
                {
                    tile = LoadTile(settings.mapData.conveyorBelt.prefab, center, cPosition);
                }
                else
                {
                    tile = LoadTile(settings.mapData.tile.prefab, center, cPosition);
                    tiles.Add(tile);
                }
                tile.transform.SetParent(parent);
                yield return new WaitForSeconds(settings.mapData.buildSpeed);
            }
            cPosition.x = center.position.x;
        }
        player.transform.position = parent.position;
        player.SetActive(true);
    }
}

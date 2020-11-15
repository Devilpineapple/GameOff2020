using System.Collections;
using Data;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public MapData settings;
    public SectionController teamA;
    public SectionController teamB;
    public Camera cam;

    private void Awake()
    {
        // cam.transform.localPosition = new Vector3(settings.mapData.dimension.width / 2, settings.mapData.dimension.height, -settings.mapData.dimension.height / 2);
        teamA.Setup(settings.mapData.dimension, -1);
        teamB.Setup(settings.mapData.dimension, 1);
        // StartCoroutine(BuildGrid(teamA));
        // StartCoroutine(BuildGrid(teamB));
    }

    private GameObject LoadTile(GameObject tile, Transform parent, Vector3 position)
    {
        var instance = Instantiate(tile, position, Quaternion.identity, parent);
        // instance.transform.localScale = new Vector3(settings.mapData.tile.size, settings.mapData.tile.size, settings.mapData.tile.size);
        return instance;
    }

    // private IEnumerator BuildGrid(SectionController team)
    // {
    //     var cPosition = team.transform.position;
    //     for (var i = 0; i < settings.mapData.dimension.height; i++)
    //     {
    //         cPosition.z--;
    //         for (var o = 0; o < settings.mapData.dimension.width; o++)
    //         {
    //             cPosition.x++;
    //             // if (o == (settings.mapData.dimension.width / 2) - 1)
    //             // {
    //             //     team.MoveCamera(75, new Vector2(cPosition.x, cPosition.z), 0.5f);
    //             // }
    //
    //             GameObject tile;
    //             if (i == 0 && o == settings.mapData.dimension.width - 1)
    //             {
    //                 tile = LoadTile(settings.mapData.voidPlatform.prefab, team.transform, cPosition);
    //             }
    //             else if (i == settings.mapData.dimension.height - 1 && o == settings.mapData.dimension.width - 1)
    //             {
    //                 tile = LoadTile(settings.mapData.dispenser.prefab, team.transform, cPosition);
    //             }
    //             else if (o == 0 || i == 0 || i == settings.mapData.dimension.height - 1)
    //             {
    //                 tile = LoadTile(settings.mapData.wall.prefab, team.transform, cPosition);
    //             }
    //             else if (o == settings.mapData.dimension.width - 1)
    //             {
    //                 tile = LoadTile(settings.mapData.conveyorBelt.prefab, team.transform, cPosition);
    //             }
    //             else
    //             {
    //                 tile = LoadTile(settings.mapData.tile.prefab, team.transform, cPosition);
    //                 team.tiles.Add(tile);
    //             }
    //             tile.transform.SetParent(team.terrain);
    //             yield return new WaitForSeconds(settings.mapData.buildSpeed);
    //         }
    //         cPosition.x = team.transform.position.x;
    //     }
    //     team.ShowCamera(() =>
    //     {
    //         team.player.transform.position = new Vector3(team.terrain.position.x, team.terrain.position.y + 1, team.terrain.position.z);
    //         // Destroy(cam.gameObject);
    //         // cam.gameObject.SetActive(false);
    //     });
    //     // team.MoveCamera(60, new Vector2(team.terrain.position.x, team.terrain.position.z), 0.5f);
    //     // team.player.transform.position = new Vector3(team.terrain.position.x, team.terrain.position.y + 1, team.terrain.position.z);
    //     // team.cam.GetComponent<CameraController>().active = true;
    //     // team.cam.transform.SetParent(team.player.transform.GetChild(0));
    //     team.player.gameObject.SetActive(true);
    // }
}

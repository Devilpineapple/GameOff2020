using System.Collections;
using CameraController;
using Data;
using UnityEngine;

namespace Absolute
{
    public class OneCamMapController : MonoBehaviour
    {
        public MapData settings;
        public SectionController teamA;
        public SectionController teamB;
        public Camera cam;

        private void Awake()
        {
            settings.mapData.Setup();
            cam.transform.localPosition = new Vector3(0, settings.mapData.dimension.height, -(settings.mapData.dimension.height / 2f) - 0.5f);
            cam.GetComponent<MultipleTargetCamera>().enabled = false;
            teamA.Setup(settings.mapData.dimension);
            teamB.Setup(settings.mapData.dimension);
            switch (settings.mapData.buildType)
            {
                case MapData.Map.BuildType.OneByOne:
                    StartCoroutine(OneByOne(teamA, teamB));
                    break;
                case MapData.Map.BuildType.RowByRow:
                    StartCoroutine(RowByRow(teamA, teamB));
                    break;
            }
        }
    
        private GameObject LoadTile(GameObject tile, Transform parent, Vector3 position)
        {
            var instance = Instantiate(tile, position, Quaternion.identity, parent);
            instance.transform.localScale = new Vector3(settings.mapData.tiles.size, settings.mapData.tiles.size, settings.mapData.tiles.size);
            return instance;
        }

        #region BuildTypes

        private void LoadTeamTile(Vector2Int d, SectionController t, Vector3 position)
        {
            var tile = LoadTile(settings.mapData.tiles.array[d.x, d.y], t.transform, position);
            tile.transform.SetParent(t.terrain);
            t.platforms.Add(tile);
        }

        private IEnumerator OneByOne(SectionController a, SectionController b)
        {
            var aPosition = a.transform.position;
            var bPosition = b.transform.position;
            for (var x = 0; x < settings.mapData.dimension.height; x++)
            {
                aPosition.z--;
                bPosition.z--;
                for (var y = 0; y < settings.mapData.dimension.width; y++)
                {
                    aPosition.x++;
                    bPosition.x = settings.mapData.dimension.width - (y + 1);
                    LoadTeamTile(new Vector2Int(x, y), a, aPosition);
                    LoadTeamTile(new Vector2Int(x, y), b, bPosition);
                    yield return new WaitForSeconds(settings.mapData.buildSpeed);
                }
                aPosition.x = a.transform.position.x;
                bPosition.x = b.transform.position.x;
            }
            cam.GetComponent<MultipleTargetCamera>().enabled = true;
            a.EnablePlayer();
            b.EnablePlayer();
        }

        private IEnumerator RowByRow(SectionController a, SectionController b)
        {
            var aPosition = a.transform.position;
            var bPosition = b.transform.position;
            for (var x = 0; x < settings.mapData.dimension.height; x++)
            {
                aPosition.z--;
                bPosition.z--;
                for (var y = 0; y < settings.mapData.dimension.width; y++)
                {
                    aPosition.x++;
                    bPosition.x = settings.mapData.dimension.width - (y + 1);
                    LoadTeamTile(new Vector2Int(x, y), a, aPosition);
                    LoadTeamTile(new Vector2Int(x, y), b, bPosition);
                }
                yield return new WaitForSeconds(settings.mapData.buildSpeed);
                aPosition.x = a.transform.position.x;
                bPosition.x = b.transform.position.x;
            }
            cam.GetComponent<MultipleTargetCamera>().enabled = true;
            a.EnablePlayer();
            b.EnablePlayer();
        }

        #endregion
    }
}
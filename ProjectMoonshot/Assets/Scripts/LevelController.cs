using System.Collections;
using CameraController;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public TeamManager teamAManager;
    public TeamManager teamBManager;
    public Camera cam;
    
    private void Start()
    {
        cam.GetComponent<MultipleTargetCamera>().enabled = false;
        StartCoroutine(Build());
    }

    private IEnumerator Build()
    {
        teamAManager.SpawnWalls();
        teamBManager.SpawnWalls();
        yield return new WaitForSeconds(0.5f);
        teamAManager.SpawnGround();
        teamBManager.SpawnGround();
        yield return new WaitForSeconds(0.5f);
        teamAManager.SpawnItemPool();
        teamBManager.SpawnItemPool();
        yield return new WaitForSeconds(0.5f);
        teamAManager.SpawnPlayer();
        teamBManager.SpawnPlayer();
        cam.GetComponent<MultipleTargetCamera>().enabled = true;
    }
}
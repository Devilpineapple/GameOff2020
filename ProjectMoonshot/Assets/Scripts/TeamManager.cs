using Player;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public Transform playerSpawn;
    public PlayerController player;
    public GameObject walls;
    public GameObject itemPool;
    public GameObject ground;

    private void Awake()
    {
        walls.SetActive(false);
        itemPool.SetActive(false);
        ground.SetActive(false);
    }

    public void SpawnWalls()
    {
        walls.SetActive(true);
    }

    public void SpawnItemPool()
    {
        itemPool.SetActive(true);
    }

    public void SpawnGround()
    {
        ground.SetActive(true);
    }

    public void EnablePlayer()
    {
        player.transform.position = playerSpawn.position;
        player.gameObject.SetActive(true);
    }
}
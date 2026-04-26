using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int tileLength = 30;
    public int tilesOnScreen = 5;
    public Transform player;
    public GameObject[] obstaclePrefabs;
    public int obstaclesPerTile = 3;
    public float laneOffset = 2.5f;
    private float spawnZ = 0;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (tilesOnScreen * tileLength))
        {
            SpawnTile();
        }

        DeleteTile();
    }
    void SpawnObstacles(GameObject tile)
    {
        for (int i = 0; i < obstaclesPerTile; i++)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject prefab = obstaclePrefabs[index];

            int lane = Random.Range(-1, 2);
            float xPos = lane * laneOffset;

            float zPos = Random.Range(
                tile.transform.position.z - tileLength / 2 + 2,
                tile.transform.position.z + tileLength / 2 - 2
            );

            float yPos = 0.5f;

        
            if (index == 0)
            {
                yPos = 1.5f;
            }

            Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

            GameObject obstacle = Instantiate(prefab, spawnPos, Quaternion.identity);
            obstacle.transform.parent = tile.transform;
        }
    }
    void SpawnTile()
    {
        Vector3 pos = new Vector3(0, 0, spawnZ + tileLength / 2);
        GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);

        activeTiles.Add(tile); 
        SpawnObstacles(tile);
        spawnZ += tileLength;
    }

    void DeleteTile()
    {
        if (activeTiles.Count == 0) return;

        if (player.position.z - activeTiles[0].transform.position.z > tileLength)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}
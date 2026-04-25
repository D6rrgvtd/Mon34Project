using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int tileLength = 30;
    public int tilesOnScreen = 5;
    public Transform player;

    private float spawnZ = 0;

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - tilesOnScreen * tileLength)
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        Instantiate(tilePrefab, Vector3.forward * spawnZ, Quaternion.identity);
        spawnZ += tileLength;
    }
}
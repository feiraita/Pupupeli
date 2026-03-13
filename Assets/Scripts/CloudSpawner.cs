using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab1;
    public GameObject cloudPrefab2;
    public Transform mainCamera;

    public float xOffset = 10f;
    public float yOffset = 2f;
    public float xOffsetCloud2 = 12f;
    public float yOffsetCloud2 = 4f;

    public float spawnInterval = 3f;
    //Pilvien kooot, voi vaihtaa unityssä helposti kun nämä ovat public
    public float cloud1Scale = 1f;
    public float cloud2Scale = 1f;

    void Start()
    {
        InvokeRepeating("SpawnCloud", 1f, spawnInterval);
        InvokeRepeating("SpawnCloud2", 2f, spawnInterval * 1.5f);
    }
    // Spawnaa ykkös prefab pilven
    void SpawnCloud()
    {
        Vector3 spawnPosition = new Vector3(
            mainCamera.position.x + xOffset,
            mainCamera.position.y + yOffset,
            0f
        );

        GameObject cloud = Instantiate(cloudPrefab1, spawnPosition, Quaternion.identity);
        cloud.transform.localScale = Vector3.one * cloud1Scale;
    }

    void SpawnCloud2()
    {
        Vector3 spawnPosition = new Vector3(
            mainCamera.position.x + xOffsetCloud2,
            mainCamera.position.y + yOffsetCloud2,
            0f
        );

        GameObject cloud = Instantiate(cloudPrefab2, spawnPosition, Quaternion.identity);
        cloud.transform.localScale = Vector3.one * cloud2Scale;
    }
}
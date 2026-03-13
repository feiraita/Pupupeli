using UnityEngine;

public class Cloud1 : MonoBehaviour
{
    public GameObject prefabPilvi;
    public GameObject spawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            Instantiate(prefabPilvi, new Vector3(i * 2.0f, i + 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

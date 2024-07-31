using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineController : MonoBehaviour
{
    public GameObject prefabM;
    public GameObject prefabF;
    public int numberOfPrefabs = 10; // Total number of prefabs to instantiate
    public float ySpacing = 2f; // Space between each prefab on the y-axis

    void Start()
    {
        CreateLineOfPrefabs();
    }

    void CreateLineOfPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject prefab = Random.Range(0, 2) == 0 ? prefabM : prefabF;
            Vector3 spawnPosition = new Vector3(0, i * ySpacing, 0);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
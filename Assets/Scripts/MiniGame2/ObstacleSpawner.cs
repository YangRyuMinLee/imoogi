using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool canSpawn = false;
    public float spawnInterval = 0.5f;
    [SerializeField] private float minHeight = -3f;
    [SerializeField] private float maxHeight = 3f;

    [Header("Prefab")] 
    [SerializeField] private GameObject obstacle;
    
    private float time = 0f;
    
    public void StartSpawn()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (!canSpawn) return;

        time += Time.deltaTime;
        if (time < spawnInterval) return;

        time = 0f;

        Vector2 pos = new Vector2(transform.position.x, UnityEngine.Random.Range(minHeight, maxHeight));
        var obs = Instantiate(obstacle, pos, Quaternion.identity);
    }
}

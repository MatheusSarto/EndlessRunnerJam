using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
namespace Assets.Scripts
{
    public class LoadLevelsManager : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private GameObject[] SegmentPrefabs;
    /// <summary>
    /// How Many Segments Will Be Spawned When Game Starts
    /// </summary>
    [SerializeField] private int InitialSegments = 5; 


    private List<GameObject> activeSegments = new List<GameObject>();

    private float SegmentLength = 40f;   
    private float spawnX = 0f;   


    private void Start()
    {
        for (int i = 0; i < InitialSegments; i++)
        {
            SpawnSegment();
        }
    }

    private void Update()
    {
        if(activeSegments.Count > 0 && PlayerTransform.transform.position.x > activeSegments[0].transform.position.x + SegmentLength)
        {
            Destroy(activeSegments[0]);
            activeSegments.RemoveAt(0);

            SpawnSegment();
        }
    }

    // Spawns a Random Segment
    void SpawnSegment()
    {
        
        int randomIndex = Random.Range(0, SegmentPrefabs.Length);
        GameObject segmentPrefab = SegmentPrefabs[randomIndex];
        
        Vector3 spawnPosition = new Vector3(spawnX, 0f, 0f);
        spawnX += SegmentLength;

        GameObject newSegment = Instantiate(segmentPrefab, spawnPosition, Quaternion.identity);
        activeSegments.Add(newSegment);  
    }
}
}

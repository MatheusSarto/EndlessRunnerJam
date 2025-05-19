using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector2 topRight;
    [SerializeField] private Vector2 bottomLeft;
    [SerializeField] private int enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {

        for(int i = 0; i < enemyCount; i++)
        {
            Vector3 rootPosition = this.transform.root.transform.position;
            Vector2 enemyPos = new
            (

                Random.Range(rootPosition.x + topRight.x, rootPosition.x + bottomLeft.x),
                Random.Range(rootPosition.y + topRight.y, rootPosition.y + bottomLeft.y)
            );

            Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
        }
    }
}

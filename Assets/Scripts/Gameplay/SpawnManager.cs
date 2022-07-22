using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;
    [SerializeField]
    List<GameObject> obstaclePrefabs = new List<GameObject>();
    [SerializeField]
    GameObject colorChanger;
    Vector3 offset = new Vector3(0, 60f, 0);
    Vector3 offsetObstacle = new Vector3(0, 8f, 0);

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Instantiate(colorChanger, new Vector2(0, -5), Quaternion.identity);
        startingSpawning(new Vector3(0, 5, 0));
        startingSpawning(new Vector3(0, 20, 0));
        startingSpawning(new Vector3(0, 35, 0));
        startingSpawning(new Vector3(0, 50, 0));
    }



    public void InstantiateNew(Vector3 pos)
    {
        int randIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject ins = obstaclePrefabs[randIndex];
        Vector3 newPos = new Vector3(0 , pos.y + offset.y, 0);

        Instantiate(colorChanger, newPos, Quaternion.identity);

        newPos.x = ins.transform.position.x;
        Instantiate(ins, newPos + offsetObstacle, Quaternion.identity);        
    }

    void startingSpawning(Vector3 pos)
    {
        int randIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject prefab = obstaclePrefabs[randIndex];

        pos += prefab.transform.position;

        Instantiate(prefab, pos, Quaternion.identity);
    }
}

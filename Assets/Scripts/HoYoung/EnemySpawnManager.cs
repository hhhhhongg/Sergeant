using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefebs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    private void spawnEnemy()
    {
        //int enemyCount = 2;
        int enemyCount = Random.Range(1, 4);

        for(int cnt = 0; cnt < enemyCount; cnt++)
        {
            Vector3 initPosition = new Vector3(Random.Range(gameObject.transform.position.x-1, gameObject.transform.position.x+ 2), Random.Range(gameObject.transform.position.y - 1, gameObject.transform.position.y+2), 0);
            Vector3 initRotate = new Vector3(0, 0, 0);
            Instantiate(enemyPrefebs[Random.Range(0, enemyPrefebs.Count)], initPosition, Quaternion.Euler(initRotate));
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnManager : MonoBehaviour
{
    public List<GameObject> BossList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnBoss();
    }

    // Update is called once per frame
    private void spawnBoss()
    {
        Vector3 initPosition = new Vector3(Random.Range(gameObject.transform.position.x - 1, gameObject.transform.position.x + 2), Random.Range(gameObject.transform.position.y - 1, gameObject.transform.position.y + 2), 0);
        Vector3 initRotate = new Vector3(0, 0, 0);
        Instantiate(BossList[Random.Range(0, BossList.Count)], initPosition, Quaternion.Euler(initRotate));
    }
}

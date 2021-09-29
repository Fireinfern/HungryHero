using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactoryController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnableObjects;

    private float Timer = 5.0f;

    void Update() {
        Timer -= Time.deltaTime;
        if(Timer < 0.0f){
            Timer = 5.0f;
            SpawnObject();
        }
    }

    void SpawnObject() {
        int index = Random.Range(0, spawnableObjects.Count);
        Instantiate(spawnableObjects[index], transform.position, Quaternion.identity);
    }
}

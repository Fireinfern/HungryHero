using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryDestructor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Damage" || other.tag == "Coffee"){
            Destroy(other.gameObject);
        }
    }
}

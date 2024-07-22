using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.tag == "obs"){
            Destroy(gameObject);
        }
    }
}

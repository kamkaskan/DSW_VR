using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] bool successCatcher;
    [SerializeField] BallManager manager;
    void OnTriggerEnter(Collider coll) {    
        if (coll.CompareTag("Ball")) {
            Destroy(coll.gameObject);
            manager.BallCatched(successCatcher);
        }
    }
}

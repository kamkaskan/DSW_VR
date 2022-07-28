using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float currentDifficulty = 0f;
    [SerializeField] bool clockwiseDir;

    public void SetDifficulty(float difficulty) {currentDifficulty = difficulty;} 
    void Update()
    {
        float speed = Mathf.Lerp(minSpeed, maxSpeed, currentDifficulty) * Time.deltaTime;
        
        if (clockwiseDir) this.transform.Rotate(Vector3.forward, -speed);   
        else this.transform.Rotate(Vector3.forward, speed);  
        
        if (transform.rotation.eulerAngles.z >= 110f && transform.rotation.eulerAngles.z <= 250f ) {
            
            if (clockwiseDir) transform.rotation = Quaternion.Euler(0,0,250f);
            else transform.rotation = Quaternion.Euler(0,0,110f);
            clockwiseDir = !clockwiseDir;
        }
    }
}

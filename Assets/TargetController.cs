using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject pfTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Random.value <= .03) {
            // create new thing
            Instantiate(pfTarget, new Vector3(12,Random.Range(-2,5),0),Quaternion.identity);
        }
    }
}
//changing to test it
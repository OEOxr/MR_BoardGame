using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinanim : MonoBehaviour
{
    int multiplier = 1;
    float timerange = 2f;
    float lastframe;
    float rotateamount = 0.002f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        print(Time.time);
        print("-- "+Time.time%timerange);
        if ((Time.time % timerange)-(lastframe % timerange) < 0)
            multiplier *= -1;
        this.transform.RotateAround(Vector3.up, multiplier*rotateamount);
        lastframe = Time.time;
    }
}

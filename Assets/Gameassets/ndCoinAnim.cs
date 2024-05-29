using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ndCoinAnim : MonoBehaviour
{

    public float ang = 0.015f;
    public float angRNG = 0.6f;
    public Vector3 myaxis = Vector3.up;
    public float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(myaxis, ang);
        counter += ang;
        if (counter % 40f < 0.1f)
            if (ang < 0.03f)
                ang = 0.03f;
            else
                ang = 0.015f;


    }
}

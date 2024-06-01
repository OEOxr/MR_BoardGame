using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinrotation : MonoBehaviour
{

    /*
     * Atanan objeye dönme ve yukarı aşağıya hareket etme animasyonu ekler.
     * Jeton için kullanıldı
     * 
     */
    public float angle = 0.02f;
    public float posamount = 0.02f;
    public float range = 0.9f;
    public float lastangle = 0;


    // Update is called once per frame
    void Update()
    {
        if (lastangle > range || lastangle < range * -1)
        {
            angle = angle * -1;
        }

        if(lastangle > (range*0.6f) || lastangle < range*-.6f)
            posamount *= -1;



        this.transform.RotateAround(Vector3.up, angle);
        lastangle += angle;
        this.transform.position += new Vector3(0, posamount, 0);
    }
}

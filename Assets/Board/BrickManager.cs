using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * oyunun içindeki taşlara sırayla bir numara verir.
 * her taşın BrickData komponentinde bricknoya ekler.
 */
public class BrickManager : MonoBehaviour
{
    public int no = 0;
    // Start is called before the first frame update
    void Start()
    {
        NumerateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NumerateBricks()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            Transform child = transform.GetChild(i);
            for(int j=0;j<child.childCount;j++)
            {
                child.GetChild(j).GetComponent<BrickData>().brickno = ++no;
            }
        }
    }
}

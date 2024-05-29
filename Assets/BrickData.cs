using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    empty = 0,
    start = 1,
    red,
    green,
    gold,
    finish,

}

public class BrickData : MonoBehaviour
{

    public CellType mytype = CellType.empty;
    public int brickno;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Pscore>() != null && other.GetComponent<Pscore>().activeplayer)
            if (other.GetComponent<Pscore>().gameposition == brickno) {
                switch (mytype) {
                    case CellType.red:
                        other.GetComponent<Pscore>().budget -= 10;
                        break;
                    case CellType.green:
                        other.GetComponent<Pscore>().score += 20;
                        break;
                    case CellType.gold:
                        other.GetComponent<Pscore>().budget += 30;
                        break;
                    
                }
                other.GetComponent<Pscore>().score += 2;
            }
    }   
}

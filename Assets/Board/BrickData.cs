using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * Bu component, oyunun içindeki adım taşlarının çeşidini ve oyuncu geldiğinde vereceği tepkileri belirler.
 * Oyuncuların oyunda gidebilecekleri her taşa component olarak atanmalı.
 * 
 */

//oyundaki taşların çeşitleri
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

    //bu taşın çeşidi
    public CellType mytype = CellType.empty;

    //kaç numaralı taş olduğu
    public int brickno;

    //konfeti atmak için ilgili prefab.
    public GameObject konfeti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Oyuncu bu taş geldiğinde oyuncuya vereceği puanlama ve diğer tepkiler
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
                        Instantiate(konfeti, this.transform);
                        break;
                    case CellType.gold:
                        other.GetComponent<Pscore>().budget += 30;
                        break;
                    
                }
                other.GetComponent<Pscore>().score += 2;
            }
    }   
}

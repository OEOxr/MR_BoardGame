using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

/*
 * 
 * Satranç oyunu için her taşa eklenebilecek taş bilgisi ve eğer üstüne gelindiyse, kendini yok eder.
 */
public enum chesspieces
{
    piyon,
    kale,
    at,
    fil,
    vezir,
    sah
}

public class pawnControl : MonoBehaviour
{

    public chesspieces CPType;

    //0:piyon, 1 kale, 2 at, 3 fil,.. 6 sah
    //public int CPType;

    public bool grabbed = false;
    public int player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grabbed()
    {
        grabbed = !grabbed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!grabbed)
        {
            if (this.CPType == chesspieces.sah)
                print("Oyunu kaybettin, oyuncu" + player);
            Destroy(this);

        }

    }
}

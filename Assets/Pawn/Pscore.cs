using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Oyundaki oyuncuların bilgisini tutar.
 * Oyunun başında oluşturulan piyona gmeman(gamemanager) tarafından otomatik eklenir.
 * 
 */
public class Pscore : MonoBehaviour
{

    //Oyuncunun ismi 
    public string PName;

    //Oyuncunun puanı
    public int score = 0;

    //Oyuncunun parası
    public int budget = 200;

    //Oyuncunun pozisyonu
    public int gameposition = 0;

    //Oyuncunun aktif olup olmadığı
    public bool activeplayer = false;

    //Oyuncuya aktif olduğunu gösteren indicatörün prefabı
    public GameObject indprefab;

    //Oyuncuya eklenen indicatörün kendisi
    public GameObject indicator;



    // Start is called before the first frame update
    void Start()
    {
        //Oyunun başında oyuncuya indicatör ekliyoruz.
        indicator = Instantiate(indprefab, this.transform);
    }


    //Oyuncu aktif/pasif olarak işaretler ve indicatörü görünür kılar
    public void ActivateMe()
    {
            activeplayer = !(activeplayer);
            indicator.SetActive(activeplayer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Bu component, çöp kutusu şeklinde hazırlanan asset ile kendisine atılan oyuncuları 
 * gmeman(gamemanager) DeletePlayer fonksiyonu ile oyuncu listesinden siler
 * 
 */
public class eraser : MonoBehaviour
{
    //çarpışmada hangi renge dönüşeceğini belirleyen değişken
    public Color activecolor=new Color(1f,0,0);

    //oyunun bilgisini tutan gamemanager componentini tutar
    public gmeman gamemanager;


    //herhangi bir şey çarptığında kendi rengini kırmızıya dönüştürür
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", activecolor);
    }


    //çarpışma bittiğinde çarpan obje piyonsa, ilgili oyuncu ve piyonu oyundan siler
    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.1415f, 0.1415f, 0.1415f));

        if (other.GetComponent<Pscore>() && gamemanager != null)
        {
            for(int i=0;i<gamemanager.players.Count;i++)
            {
                if (other.GetComponent<Pscore>().PName == gamemanager.players[i].GetComponent<Pscore>().PName)
                    gamemanager.DeletePlayer(i);
            }

        }

    }
}

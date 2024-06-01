using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

/* Bu component oyunun genel yönetimini ve oyuncuların puan, pozisyonlarını takip etmekte.
 * 
 * 
 * 
 * 
 * 
 */
public class gmeman : MonoBehaviour
{
    //Oyunculara atanabilecek piyon prefablerini tutan listemiz
    public List<GameObject> pawns;

    //Oyun sırasındaki aktif oyuncular
    public List<GameObject> players;

    //Oyun sırasında son atılan zarın değeri
    public int dice;

    //Sıranın hangi oyuncuda olduğu bilgisi
    public int activeplayer;
    //Sıranın hangi piyonda olduğunun göstergesi için prefab
    public GameObject activeplindicator;

    //Scoreboarddaki yazı alanları (ScoraboardTxt de farklı örnek olması amacıyla gameobject olarak alındı
    public TMP_Text DiceTxt;
    public TMP_Text ActivePlayerTxt;
    public GameObject   ScoreboardTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //Oyuna yeni oyuncu ekler
    public void AddPlayer()
    {
        if(pawns.Count>players.Count)
        {
            //yeni bir piyon oluşturur ve oyuncu listesine yeni oyuncu ekler  (GAMEMANAGERIN altına)
            players.Add(
                Instantiate(pawns[players.Count], this.transform)
            );
            //Son eklenen oyuncuya Pscore adında, yazdığımız player datası için componenti ekler ve isimini yazar
            players[players.Count - 1].AddComponent<Pscore>();
            players[players.Count - 1].GetComponent<Pscore>().PName = "Player-" + players.Count;
            //aktif oyuncu göstermek için kullandığımız indicatörün prefabını ekler
            players[players.Count - 1].GetComponent<Pscore>().indprefab = activeplindicator;

        }
        
        UpdScoreBoard();
    }


    //Oyuncu listesinde x sırasındaki oyuncuyunun piyonunu yok eder ve oyuncu listeden siler.
    public void DeletePlayer(int x=-1)
    {
        //Eğer x değeri verilmediyse, -1 olarak kabul eder ve bu durumda son oyuncuyu siler
        if (x < 0)
            x = players.Count - 1;


        if(players.Count>x)
        {
            Destroy(players[x]);
            players.RemoveAt(x);
        }
    }

    //Oyun sırasını sonraki oyuncuya aktarır.
    public void NextPly()
    {
        GameObject ind;
        if (activeplayer == null || activeplayer <0)
            activeplayer = 0;
        else
        {
            players[activeplayer].GetComponent<Pscore>().ActivateMe();
            //PlayerIndicator(players[activeplayer]);

            activeplayer++;
            activeplayer %= players.Count;

        }

        players[activeplayer].GetComponent<Pscore>().ActivateMe();
        // PlayerIndicator(players[activeplayer]);


        ActivePlayerTxt.text = players[activeplayer].GetComponent<Pscore>().PName + " is playing !";
        
        players[activeplayer].GetComponent<Pscore>().gameposition += Zar();
    }


    //1-6 arasında bir değer yaratıyor ve dice değişkenini güncelliyor
    public int Zar()
    {
        dice = Random.Range(1, 7);
        DiceTxt.text = dice.ToString();
        UpdScoreBoard();
        return dice;
    }

    //scoreboardu güncelliyor
    public void UpdScoreBoard()
    {
        if (ScoreboardTxt != null)
        {
            ScoreboardTxt.GetComponent<TMP_Text>().text = "";
            for (int i = 0; i < players.Count; i++)
                ScoreboardTxt.GetComponent<TMP_Text>().text += players[i].GetComponent<Pscore>().PName + " : " + players[i].GetComponent<Pscore>().score + "  -   " + players[i].GetComponent<Pscore>().budget + "\n";
        }
    }


 // public void PlayerIndicator(GameObject ply)
 // {
 //     bool found = false;
 //     int i = 0;
 //     GameObject ind = ply.transform.GetChild(i).gameObject;
 //
 //     for (; i < ply.transform.childCount; i++)
 //     {
 //         ind = ply.transform.GetChild(i).gameObject;
 //         if (ind.name== activeplindicator.name)
 //         {
 //             found = true;
 //             break;
 //         }
 //
 //     }
 //
 //     if (!found)
 //         ind = Instantiate(activeplindicator, ply.transform);
 //     else
 //         ind.SetActive(ply.GetComponent<Pscore>().activeplayer);
 // }
}

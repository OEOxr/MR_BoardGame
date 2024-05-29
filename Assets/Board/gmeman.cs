using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gmeman : MonoBehaviour
{
    public List<GameObject> pawns;
    public List<GameObject> players;
    public int dice;

    public int activeplayer;
    public GameObject activeplindicator;

    public TMP_Text DiceTxt;
    public TMP_Text ActivePlayerTxt;
    public GameObject   ScoreboardTxt;

    // Start is called before the first frame update
    void Start()
    {
        AddPlayer();
        AddPlayer(); AddPlayer(); AddPlayer();
        NextPly(); NextPly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddPlayer()
    {
        if(pawns.Count>players.Count)
        {
            players.Add(
                Instantiate(pawns[players.Count], this.transform)
            );
            players[players.Count - 1].AddComponent<Pscore>();
            players[players.Count - 1].GetComponent<Pscore>().PName = "Player-" + players.Count;

        }
        UpdScoreBoard();
    }

    public void DeletePlayer(int x=-1)
    {
        if (x < 0)
            x = players.Count - 1;

        if(players.Count>x)
        {
            Destroy(players[x]);
            players.RemoveAt(x);
        }
    }

    public void NextPly()
    {
        GameObject ind;
        if (activeplayer == null || activeplayer <0)
            activeplayer = 0;
        else
        {
            players[activeplayer].GetComponent<Pscore>().activeplayer = false;
            activeplayer++;
            activeplayer %= players.Count;

        }
        ActivePlayerTxt.text = players[activeplayer].GetComponent<Pscore>().PName + " is playing !";
        players[activeplayer].GetComponent<Pscore>().activeplayer = true;

        ind = Instantiate(activeplindicator, players[activeplayer].transform);

        players[activeplayer].GetComponent<Pscore>().gameposition += Zar();
    }

    public int Zar()
    {
        dice = Random.Range(1, 7);
        DiceTxt.text = dice.ToString();
        UpdScoreBoard();
        return dice;
    }

    public void UpdScoreBoard()
    {
        if (ScoreboardTxt != null)
        {
            ScoreboardTxt.GetComponent<TMP_Text>().text = "";
            for (int i = 0; i < players.Count; i++)
                ScoreboardTxt.GetComponent<TMP_Text>().text += players[i].GetComponent<Pscore>().PName + " : " + players[i].GetComponent<Pscore>().score + "  -   " + players[i].GetComponent<Pscore>().budget + "\n";
        }
    }


    public void PlayerIndicator(GameObject ply, bool s=true)
    {
        bool found = false;
        int i = 0;
        GameObject ind = ply.transform.GetChild(i).gameObject;

        for (; i < ply.transform.childCount; i++)
        {
            ind = ply.transform.GetChild(i).gameObject;
            if (ind.name== activeplindicator.name)
            {
                found = true;
            }

        }

        if (!found)
            ind = Instantiate(activeplindicator, ply.transform);
        else
            ind.SetActive(s);
    }
}

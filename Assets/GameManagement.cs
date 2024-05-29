using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManagement : MonoBehaviour
{
    public List<GameObject> pawns;
    public List<GameObject> players;
    public int round = 0;




    // Start is called before the first frame update
    void Start()
    {
        AddPlayer();
        AddPlayer();
        NextPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer()
    {
        int p = players.Count;

        if (pawns.Count>0 && players.Count<pawns.Count)
        {
            players.Add(Instantiate(pawns[p], transform.parent));
            players[p].AddComponent<PlayerData>();
            players[p].GetComponent<PlayerData>().name = "Player " + (p+1);

        }
    }



    public void NextPlayer()
    {
        round += 1;
        round %= players.Count;

        UpdateScreen();
    }

    public void UpdateScreen()
    {
        print("Sıra Player " + round + " de");
    }
}

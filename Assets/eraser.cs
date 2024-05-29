using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eraser : MonoBehaviour
{

    public Color activecolor=new Color(1f,0,0);
    public gmeman gamemanager;

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
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", activecolor);
    }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifasTest : MonoBehaviour
{
    public GameObject NPC, Player, npcver;

    // Start is called before the first frame update
    void Start()
    {   
        Player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(npcver.transform.position, Player.transform.position) < 170)
        {
            NPC.SetActive(true);
        }
        else
        {
            NPC.SetActive(false);
        }
      
    }
}

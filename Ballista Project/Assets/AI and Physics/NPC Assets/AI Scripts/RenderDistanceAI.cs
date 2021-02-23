using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDistanceAI : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NPCParent;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        NPC = gameObject.transform.GetChild(0).gameObject;
        NPCParent = gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        float distancetoplayer = Vector3.Distance(Player.transform.position, NPC.transform.position);

        if (distancetoplayer < 20)
        {
            NPC.SetActive(false);
        }
        if (distancetoplayer > 20)
        {
            NPC.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class camera : MonoBehaviour
{

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.target = player.transform;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}

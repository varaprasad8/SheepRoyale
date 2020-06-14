using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ColourChange : MonoBehaviour
{
    //GameObject rb;

     public PhotonView photonview;
    
    // Start is called before the first frame update
    void Start()
    {
        photonview.RPC("setColor", RpcTarget.AllBuffered,null);
       //this.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {

    }


    [PunRPC]
    public void setColor()
    {
       // Debug.Log("dd");
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

}

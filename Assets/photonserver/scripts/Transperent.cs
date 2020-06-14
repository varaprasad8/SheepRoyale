using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Transperent : MonoBehaviour
{
    //public Material mat;

    PhotonView pv;

    Renderer rend;

    Color alpha;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //if (pv.IsMine)
        //{
           
        //}

        if (other.gameObject)
        {
            alpha = new Color(1f, 1f, 1f, 0.35f);
            rend.material.color = alpha;
        }

    }

    private void OnTriggerExit(Collider other)
    {
       // if(pv.IsMine)
        alpha = new Color(1f, 1f, 1f, 1f);
        rend.material.color = alpha;
    }



}

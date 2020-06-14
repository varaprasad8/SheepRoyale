using Photon.Pun;
using UnityEngine;

public class playerNetwork : MonoBehaviour
{
    public MonoBehaviour[] scriptsToIgnore;

    private PhotonView photonview;

    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();

        if (!photonview.IsMine)
        {
            foreach (var scripts in scriptsToIgnore)
            {
                scripts.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

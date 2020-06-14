using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject currHealth;
    public GameObject healthNum;

    float hitpoint = 100;
    float maxhitpoint = 100;

    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        currHealth = GameObject.Find("currhealth");
        healthNum = GameObject.Find("healthtext");
        UpdatehealthBar();
    }
    private void UpdatehealthBar()
    {
        float ratio = hitpoint / maxhitpoint;
        currHealth.GetComponent<Image>().rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthNum.GetComponent<Text>().text = (ratio * 100).ToString();
    }


    public void TakeDamage(float damage)
    {
        if (pv.IsMine)
        {
            //Debug.Log("tknDmg");
            // Debug.Log(pv.ViewID);
            hitpoint -= damage;

            if (hitpoint < 0)
            {
                hitpoint = 0;
                Debug.Log("DEAD!!!");
                PhotonNetwork.Disconnect();
                SceneManager.LoadScene(0);
            }
            UpdatehealthBar();

        }
    }

}

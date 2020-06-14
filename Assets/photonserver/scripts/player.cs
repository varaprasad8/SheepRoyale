using Photon.Pun;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform nozzle;
    public GameObject bullet;

    public Rigidbody rb;
    private HealthBar hp;


    public float damage = 10;

    PhotonView photonview;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = GameObject.Find("Player(Clone)").GetComponent<HealthBar>();

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);

        if (Input.GetMouseButtonDown(0))
        {
            PhotonNetwork.Instantiate("bullet", nozzle.transform.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject)
        {
            hp.TakeDamage(damage);
        }
    }
}

using Photon.Pun;
using System;
using UnityEngine;


public class ThirdPersonCharacterControl : MonoBehaviour
{
    public GameObject nozzle;
    public GameObject bullet;
    public GameObject target;

    public float Speed;
    public Animator anim;
    Rigidbody rb;

    private PhotonView pv;

    public AudioSource aud;

    public Vector3 playerMovement;

    public HealthBar hp;
    public float damage = 10;

    public event Action OnPlayerHide;
    public bool canMove;

    public Transform Btarget;

    //public Vector3 temp;


    private void Awake()
    {
        pv = GetComponent<PhotonView>();

    }
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        hp = GameObject.Find("sheep(Clone)").GetComponent<HealthBar>();

        if (pv.IsMine)
        {
            Camera.main.transform.SetParent(target.transform);
            Vector3 pos = target.transform.position;
            pos.z -= 2;
            Camera.main.transform.position = pos;
            Camera.main.GetComponent<ThirdPersonCameraControl>().Target = target.transform;
            Camera.main.GetComponent<ThirdPersonCameraControl>().Player = this.transform;
            Camera.main.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    void Update()
    {
        if (pv.IsMine)
        {
            PlayerMovement();
            shoot();
            sound();
        }


        // GetBaseInput();

    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float up = Input.GetAxis("Jump");

        //Debug.Log(hor);
        playerMovement = new Vector3(hor, up, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //Debug.Log("gg");
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("isThrow", true);
        }
        else
        {
            anim.SetBool("isThrow", false);
        }

        //    temp = transform.position;


        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        temp.z += Speed * Time.deltaTime;
        //        transform.position = temp;

        //        //transform.position += Vector3.forward * Speed * Time.deltaTime;
        //        anim.SetBool("isWalk", true);
        //    }
        //    if (Input.GetKey(KeyCode.S))
        //    {
        //        temp.z -= Speed * Time.deltaTime;
        //        transform.position = temp;

        //        // transform.position -= Vector3.forward * Speed * Time.deltaTime;
        //        anim.SetBool("isWalk", true);
        //    }
        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        transform.position += Vector3.left * Speed * Time.deltaTime;
        //        anim.SetBool("isWalk", true);
        //    }
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        transform.position += Vector3.right * Speed * Time.deltaTime;
        //        anim.SetBool("isWalk", true);
        //    }

    }

    public void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = PhotonNetwork.Instantiate("bullets", nozzle.transform.position, nozzle.transform.rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.TransformDirection(Vector3.forward * 10); //go.transform.forward * 10;
            Destroy(go, 5f);
        }
    }

    public void sound()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            aud.Play();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (pv.IsMine)
        {

            if (col.gameObject.tag == "Bullet")
            {
                //Debug.Log("ggh" + Time.frameCount);
                hp.TakeDamage(damage);
                Destroy(col.gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Bush")
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Collided");
                Camera.main.transform.SetParent(collision.transform);
                Vector3 pos = collision.transform.position;
                pos.z -= 2;
                Camera.main.transform.position = pos;
                Camera.main.GetComponent<ThirdPersonCameraControl>().Target = collision.transform.GetChild(0);
                Camera.main.GetComponent<ThirdPersonCameraControl>().Player = collision.transform;
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                collision.gameObject.AddComponent<Rigidbody>();
                this.gameObject.SetActive(false);
                OnPlayerHide?.Invoke();
                canMove = false;
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (pv.IsMine)
        {
            if (col.gameObject.tag == "Bullet")
            {
                Debug.Log("destroy");
            }
        }
    }
}

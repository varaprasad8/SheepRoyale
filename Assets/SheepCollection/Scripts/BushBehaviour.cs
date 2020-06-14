using System.Collections;
using UnityEngine;

public class BushBehaviour : MonoBehaviour
{
    ThirdPersonCharacterControl player;
    bool shouldMove = false;



    Vector3 bushMovement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindPlayer");
    }

    IEnumerator FindPlayer()
    {
        while (FindObjectOfType<ThirdPersonCharacterControl>() == null)
            yield return 0;
        player = FindObjectOfType<ThirdPersonCharacterControl>();
        player.OnPlayerHide += OnPlayerHide;
    }

    private void OnDisable()
    {
        player.OnPlayerHide -= OnPlayerHide;
    }
    private void OnPlayerHide()
    {
        shouldMove = true;
        player.transform.SetParent(this.transform);
        // transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.O))
            {
                player.gameObject.SetActive(true);
                player.transform.SetParent(null);
                Camera.main.transform.SetParent(player.transform);
                Rigidbody rb = this.GetComponent<Rigidbody>();
                Destroy(rb);
                shouldMove = false;
                player.canMove = true;
            }
        }
    }

    void Movement()
    {
        //transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 3f * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float up = Input.GetAxis("Jump");

        //Debug.Log(hor);
        bushMovement = new Vector3(hor, up, ver) * 5 * Time.deltaTime;
        transform.Translate(bushMovement, Space.Self);
    }
}

using UnityEngine;

public class movements : MonoBehaviour
{

    public float moveSpeed = 12;

    Rigidbody rb;

    float moveX;
    float moveZ;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3((transform.position.x) * moveX, 0f, (transform.position.z) * moveZ);
    }
}

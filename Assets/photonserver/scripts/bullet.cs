using UnityEngine;

public class bullet : MonoBehaviour
{

    Rigidbody bulletClone;



    // Start is called before the first frame update
    void Start()
    {
        bulletClone = GetComponent<Rigidbody>();
    }
}

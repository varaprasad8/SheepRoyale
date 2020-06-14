using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public Canvas canvas;
    public HealthBar healthBar;
    //public static bull

    public static GameManager instance;



    private void Awake()
    {


        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //private void Start()
    //{
    //    canvas.enabled = true;
    //}

}

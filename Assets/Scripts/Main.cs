using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }
    public Transform Player { get; private set; }

    private void Awake()
    {
        Instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void Update()
    {
        
    }
}

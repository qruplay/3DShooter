using Controller;
using Interface;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }
    public Transform Player { get; private set; }
    public PlayerController playerController;

    private IInit[] _controllersToInit;
    private IUpdate[] _controllersToUpdate;

    private void Awake()
    {
        Instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        playerController = new PlayerController(new UnitMotor(Player));
        
        _controllersToInit = new IInit[1];
        _controllersToInit[0] = playerController;
        
        _controllersToUpdate = new IUpdate[1];
        _controllersToUpdate[0] = playerController;
    }

    private void Start()
    {
        foreach (var controllerToInit in _controllersToInit)
        {
            controllerToInit.OnStart();
        }
    }

    private void Update()
    {
        foreach (var controllerToUpdate in _controllersToUpdate)
        {
            controllerToUpdate.OnUpdate();
        }
    }
}

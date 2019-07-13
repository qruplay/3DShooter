using Controller;
using Interface;
using Model;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }
    public Transform Player { get; private set; }
    public PlayerController playerController;
    public Inventory inventory;
    public InputController inputController;
    public FlashlightController flashlightController;
    public SelectionController selectionController;
    public WeaponController weaponController;

    private IInit[] _controllersToInit;
    private IUpdate[] _controllersToUpdate;

    private void Awake()
    {
        Instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        inventory = new Inventory();
        playerController = new PlayerController(new UnitMotor(Player));
        inputController = new InputController();
        flashlightController = new FlashlightController();
        selectionController = new SelectionController();
        weaponController = new WeaponController();

        _controllersToInit = new IInit[3];
        _controllersToInit[0] = inventory;
        _controllersToInit[1] = playerController;
        _controllersToInit[2] = inputController;
        
        _controllersToUpdate = new IUpdate[5];
        _controllersToUpdate[0] = playerController;
        _controllersToUpdate[1] = inputController;
        _controllersToUpdate[2] = flashlightController;
        _controllersToUpdate[3] = selectionController;
        _controllersToUpdate[4] = weaponController;
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

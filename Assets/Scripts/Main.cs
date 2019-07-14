using Controller;
using Interface;
using Model;
using Model.Weapon;
using UnityEngine;
// ReSharper disable InconsistentNaming

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; }
    public Transform Player { get; private set; }
    public PlayerController PlayerController;
    public Inventory Inventory;
    public InputController InputController;
    public FlashlightController FlashlightController;
    public SelectionController SelectionController;
    public WeaponController WeaponController;
    public ObjectPool ObjectPool;

    private IInit[] _controllersToInit;
    private IUpdate[] _controllersToUpdate;

    private void Awake()
    {
        Instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Inventory = new Inventory();
        PlayerController = new PlayerController(new UnitMotor(Player));
        InputController = new InputController();
        FlashlightController = new FlashlightController();
        SelectionController = new SelectionController();
        WeaponController = new WeaponController();
        ObjectPool = new ObjectPool();

        _controllersToInit = new IInit[3];
        _controllersToInit[0] = Inventory;
        _controllersToInit[1] = PlayerController;
        _controllersToInit[2] = InputController;
        
        _controllersToUpdate = new IUpdate[5];
        _controllersToUpdate[0] = PlayerController;
        _controllersToUpdate[1] = InputController;
        _controllersToUpdate[2] = FlashlightController;
        _controllersToUpdate[3] = SelectionController;
        _controllersToUpdate[4] = WeaponController;
        
        PrepareObjectPools();
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

    private void PrepareObjectPools()
    {
        var bulletsPollParent = GameObject.Find("Bullet");
        var bulletPrefab = Resources.Load<Bullet>("Bullet");
        ObjectPool.AddPool("Bullet", bulletPrefab, 100, bulletsPollParent.transform);
    }
}

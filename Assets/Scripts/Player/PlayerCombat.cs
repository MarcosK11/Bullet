using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Configurações")]

    private PlayerInputActions inputActions;
    private WeaponHolder weaponHolder;
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        inputActions = new PlayerInputActions();
        weaponHolder = GetComponentInChildren<WeaponHolder>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (gameManager.IsPlayerInputBlocked)
            return;

        if (inputActions.Player.Shoot.WasPressedThisFrame())
        {
            weaponHolder.CurrentWeapon.Shoot();
        }
    }
}

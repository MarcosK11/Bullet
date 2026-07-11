using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Configurações")]

    private PlayerInputActions inputActions;
    private WeaponHolder weaponHolder;

    private void Awake()
    {
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
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager != null && gameManager.IsGameOver)
            return;

        if (inputActions.Player.Shoot.WasPressedThisFrame())
        {
            weaponHolder.CurrentWeapon.Shoot();
        }
    }
}

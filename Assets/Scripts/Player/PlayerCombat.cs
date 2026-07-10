using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Configurações")]

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
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
        if (inputActions.Player.Shoot.WasPressedThisFrame())
        {
            Debug.Log("Bang!");
        }
    }
}

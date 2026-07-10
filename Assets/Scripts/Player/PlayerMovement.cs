using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rigidbody2D;
    private PlayerInputActions inputActions;
    private Vector2 direction;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

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
        direction = inputActions.Player.Move.ReadValue<Vector2>();

        Debug.Log(direction);
    }
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = direction.normalized * speed;
    }
}
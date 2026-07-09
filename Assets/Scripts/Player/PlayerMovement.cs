using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private float velocidade = 5f;

    private Rigidbody2D rb;
    private PlayerInputActions inputActions;
    private Vector2 direcao;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

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
        direcao = inputActions.Player.Move.ReadValue<Vector2>();

        Debug.Log(direcao);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = direcao.normalized * velocidade;
    }
}
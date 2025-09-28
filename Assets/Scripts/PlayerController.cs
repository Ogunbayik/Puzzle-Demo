using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerStateController stateController;

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        stateController = GetComponent<PlayerStateController>();
    }
    void Update()
    {
        SetState();

        HandleMovement();

    }
    private void SetState()
    {
        if (IsMoving())
            stateController.SwitchState(PlayerStateController.States.Move);
        else
            stateController.SwitchState(PlayerStateController.States.Idle);
    }
    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(Consts.PlayerInput.HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(Consts.PlayerInput.VERICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = movementDirection.normalized;

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        
    }
    public bool IsMoving()
    {
        return movementDirection != Vector3.zero;
    }
}

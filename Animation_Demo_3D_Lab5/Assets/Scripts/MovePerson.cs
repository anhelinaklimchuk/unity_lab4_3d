
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    CapsuleCollider capsuleCollider;
    public Transform CameraTransform;

    public CharacterStatus characterStatus;
    public Animator animator;
    private Rigidbody rb;
    
    public float vertical;
    public float horizontal;
    public float moveAmount;
    public float rotationSpeed;

    [SerializeField] private float jumpHeight;
    [SerializeField] private bool isGrounded;   
    [SerializeField] private float groundCheckDistanse;   
    [SerializeField] private LayerMask groundMask;   
    [SerializeField] private float gravity;   
    private Vector3 velocity;
    private CharacterController characterController;

    public Vector3 rotationDirection;   
    public Vector3 moveDirection;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void MoveUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistanse, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = CameraTransform.forward;
                   
        RotationNormal();       
    }

   
   
    public void RotationNormal()
    {
        if(!characterStatus.isAiming)
        {
            rotationDirection = moveDirection;
        }

        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
            targetDir = transform.forward;

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;
    }

    
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float moveSpeed = 5f;
    public float climbSpeed = 3f;

    [Header("Wwise Audio")]
    public string ladderSongEvent = "Play_Acapella";
    public string climbStepEvent = "Play_ClimbingLadder";

    private Rigidbody rb;
    private bool isClimbing = false;
    private float horizontalInput;
    private float verticalInput;

    
    private uint songPlayingID;
    private uint stepsPlayingID;
    private bool isStepsPlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        
        if (isClimbing)
        {
            
            bool isHoldingMoveKey = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

            if (isHoldingMoveKey && !isStepsPlaying)
            {
                
                stepsPlayingID = AkSoundEngine.PostEvent(climbStepEvent, gameObject);
                isStepsPlaying = true;
            }
            else if (!isHoldingMoveKey && isStepsPlaying)
            {
                
                AkSoundEngine.StopPlayingID(stepsPlayingID);
                isStepsPlaying = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
           
            rb.linearVelocity = new Vector3(0, verticalInput * climbSpeed, 0);
        }
        else
        {
           
            Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;

            
            songPlayingID = AkSoundEngine.PostEvent(ladderSongEvent, gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.useGravity = true;

            
            AkSoundEngine.StopPlayingID(songPlayingID);

            
            if (isStepsPlaying)
            {
                AkSoundEngine.StopPlayingID(stepsPlayingID);
                isStepsPlaying = false;
            }
        }
    }
}
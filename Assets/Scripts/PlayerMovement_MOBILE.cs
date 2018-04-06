using UnityEngine;

    public class PlayerMovement_MOBILE: MonoBehaviour
    {

    public float speed = 100f;
   // Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    // public joyStickScript joystick;
    public LeftJoystick joystick;
    private Vector3 leftJoystickInputOriginal;
    private Vector3 leftJoystickInput;
    public Transform rotationTarget;
    public int rotationSpeed = 8;

    void Awake()
    {

        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        leftJoystickInput = joystick.GetInputDirection();
        leftJoystickInputOriginal = leftJoystickInput;
        /*Vector3 movement = Vector3.zero;
        movement = joystick.InputDirection;
        if (movement.magnitude != 0)
        {
            movement = movement.normalized * speed * Time.deltaTime;
            movement = movement * 10;
            playerRigidbody.MovePosition(transform.position + movement);
            transform.rotation = Quaternion.LookRotation(movement);
        }
        Animating(movement.x, movement.y);*/
        float xMovementLeftJoystick = leftJoystickInput.x; // The horizontal movement from joystick 01
        float zMovementLeftJoystick = leftJoystickInput.y; // The vertical movement from joystick 01	
        anim.SetBool("IsWalking", false);
        // if there is no input on the left joystick

        // if there is only input from the left joystick
        if (leftJoystickInput != Vector3.zero)
        {
            // calculate the player's direction based on angle
            float tempAngle = Mathf.Atan2(zMovementLeftJoystick, xMovementLeftJoystick);
            xMovementLeftJoystick *= Mathf.Abs(Mathf.Cos(tempAngle));
            zMovementLeftJoystick *= Mathf.Abs(Mathf.Sin(tempAngle));

            leftJoystickInput = new Vector3(xMovementLeftJoystick, 0, zMovementLeftJoystick);
            leftJoystickInput = transform.TransformDirection(leftJoystickInput);
            leftJoystickInput *= speed;
     

            // rotate the player to face the direction of input
            Vector3 temp = transform.position;
            temp.x += xMovementLeftJoystick;
            temp.z += zMovementLeftJoystick;
            Vector3 lookDirection = (temp - transform.position);
  
            if (lookDirection != Vector3.zero)
            {
               // rotationTarget.localRotation = Quaternion.Slerp(rotationTarget.localRotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
         

            // move the player
            Vector3 moveVector = (Vector3.right * leftJoystickInputOriginal.x + Vector3.forward * leftJoystickInputOriginal.y).normalized;
           playerRigidbody.transform.Translate(moveVector *speed* Time.fixedDeltaTime,Space.World);
            anim.SetBool("IsWalking", true);
        }
    }



}
   

    
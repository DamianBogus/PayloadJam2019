using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public float BaseY;
    public float MaxY;

    public float MoveRate = 3;
    public float FlyRate = 5;
    public bool EnableFlying = true;
    public bool EnableJump = true;

    private bool shouldJump = false;

    public void Start()
    {
        if (!player) player = GetComponent<Player>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded && EnableJump)
        {
            shouldJump = true;
        }
    }

    public void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);

        //Flying
        if (!player.IsGrounded && EnableFlying)
        {
            //Flying input
            input.y = Input.GetAxis("Vertical") * 0.8f;

            if (input.y != 0)
            {
                //Scale the flying depending on the range from bottom to top.
                float currentRatio = transform.position.y - BaseY;
                currentRatio = currentRatio / (MaxY - BaseY);
                currentRatio = 1 - currentRatio;

                input.y *= FlyRate * currentRatio;
            }
        } 
        
        //Normal moving.
        player.Move(input, MoveRate);

        //Jumping
        if (shouldJump && EnableJump)
        {
            shouldJump = false;

            player.Move(new Vector2(0, 8));
        }

        if (!EnableJump) shouldJump = false;
    }
}


using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public Player player;

    public float MoveRate = 3;
    public bool EnableFlying = true;
    public bool EnableJump = true;

    private bool shouldJump = false;

    public void Start()
    {
        if (!player) player = GetComponent<Player>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded)
        {
            shouldJump = true;
        }
    }

    public void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (!player.IsGrounded)
        {
            input.y = Input.GetAxis("Vertical") * 0.8f;
        } 

        player.Move(input, MoveRate);

        if (shouldJump)
        {
            shouldJump = false;

            player.Move(new Vector2(0, 5));
        }
    }
}


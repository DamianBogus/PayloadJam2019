using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public Player player;

    public float MoveRate = 3;

    public void Start()
    {
        if (!player) player = GetComponent<Player>();
    }

    public void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);

        player.Move(input, MoveRate);
    }
}


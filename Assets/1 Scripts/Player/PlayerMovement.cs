using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public Player player;
    public float BaseY;
    public float MaxY;

    public float MoveRate = 3;
    public float FlyRate = 5;
    public float JumpRate = 15;
    public float GravityMultiplier = 3;
    public float FlyingMeter = 100;
    public float FlyingMeterMax = 100;
    public float FlyDrainRate = 8;
    public float FlyRecoverRate = 4;
    public bool EnableFlying = true;
    public bool EnableFlyingMeter = false;
    public bool EnableJump = true;

    [NonSerialized]
    public float CurrentHeightRatio;

    private bool shouldJump = false;
    private bool isFlying = false;
    private float originalGravityScale;

    public void Start()
    {
        if (!player) player = GetComponent<Player>();

        player.Killcounter.OnThresholdsPassed += ThresholdPass;
    }

    private void ThresholdPass(int count)
    {
        if(count == 1)
        {
            EnableFlyingMeter = true;
        }
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
        //Only fly if we have enough flying meter if its enabled.
        if (!player.IsGrounded && EnableFlying && (!EnableFlyingMeter || FlyingMeter != 0))
        {
            //Flying input
            input.y = Input.GetAxis("Vertical") * 0.8f;

            if (input.y != 0)
            {
                //Scale the flying depending on the range from bottom to top.
                CurrentHeightRatio = transform.position.y - BaseY;
                CurrentHeightRatio = CurrentHeightRatio / (MaxY - BaseY);
                CurrentHeightRatio = 1 - CurrentHeightRatio;

                input.y *= FlyRate * CurrentHeightRatio;

                isFlying = true;
            }
            else isFlying = false;
        }

        if (EnableFlyingMeter)
        {
            //Drain if we are flying.
            if (isFlying && FlyingMeter != 0)
            {
                FlyingMeter -= FlyDrainRate * Time.fixedDeltaTime;
                if (FlyingMeter < 0) FlyingMeter = 0;
            }
            else if (FlyingMeter != FlyingMeterMax)
            {
                FlyingMeter += FlyRecoverRate * Time.fixedDeltaTime;
                if (FlyingMeter > FlyingMeterMax) FlyingMeter = FlyingMeterMax;
            }

        }

        //Normal moving.
        player.Move(input, MoveRate);

        //Jumping
        if (shouldJump && EnableJump)
        {
            shouldJump = false;

            player.Move(new Vector2(0, JumpRate));
        }

        if (!EnableJump) shouldJump = false;

        //Increase gravity when we are in the air and falling.
        if(!player.IsGrounded && player.rb.velocity.y < 0)
        {
            player.rb.gravityScale = 3 *GravityMultiplier;
        }
        else
        {
            player.rb.gravityScale = 3;
        }
    }
}


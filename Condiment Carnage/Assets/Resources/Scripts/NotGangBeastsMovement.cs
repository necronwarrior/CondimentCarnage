﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class NotGangBeastsMovement : MonoBehaviour {
	public Vector3 forwardxz;
    float PrevInAir;
	public Rigidbody PlayerRB;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    bool OneJump;

    // Use this for initialization
    void Start () {
        forwardxz = GetComponent<Rigidbody>().transform.up;
		
	//forwardxz.y = 0;
		PlayerRB = this.GetComponent<Rigidbody> ();

        OneJump = false;

		string[] getPlayer = transform.name.Split (':');
		playerIndex = (PlayerIndex)int.Parse(getPlayer[1]);
    }
	
	// Update is called once per frame
	void FixedUpdate () {


                prevState = state;
        state = GamePad.GetState(playerIndex);

        if(prevState.ThumbSticks.Left.X < -0.1){
			PlayerRB.AddForce(Vector3.left *5.0f);
		}

		if(prevState.ThumbSticks.Left.X > 0.1){
			PlayerRB.AddForce(Vector3.right *5.0f);
		}

		if(prevState.ThumbSticks.Left.Y > 0.1)
        {
			PlayerRB.AddForce(Vector3.forward *5.0f);
		}

		if(prevState.ThumbSticks.Left.Y < -0.1)
        {
			PlayerRB.AddForce(Vector3.back *5.0f);
		}

		if(prevState.Buttons.A == ButtonState.Released && 
            state.Buttons.A == ButtonState.Pressed &&
            OneJump == true)
        {
			PlayerRB.AddForce(Vector3.up *500.0f);
		}

        if (PrevInAir == transform.position.y)
        {
            OneJump = true;
        }else
        {
            OneJump = false ;
        }


		PlayerRB.transform.up = Vector3.Lerp(Vector3.up, forwardxz, Time.fixedDeltaTime);
        PrevInAir = transform.position.y;
    }
}

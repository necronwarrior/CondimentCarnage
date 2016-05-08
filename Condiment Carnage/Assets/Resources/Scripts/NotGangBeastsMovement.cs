using UnityEngine;
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
		PlayerRB = GetComponent<Rigidbody> ();
        OneJump = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

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
           // if(PrevInAir != transform.position.y){
                OneJump = false ;
            //}
        }


		forwardxz.y = 0;
		PlayerRB.transform.up = Vector3.Lerp(Vector3.up, forwardxz, Time.deltaTime);
        PrevInAir = transform.position.y;
    }
}

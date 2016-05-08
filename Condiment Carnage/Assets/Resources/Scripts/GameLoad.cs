using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class GameLoad : MonoBehaviour {

	int stage;// specify what stage is being used

	List<PlayerIndex> playerIndex;// index list containing which players are playing
	List<GameObject> playerUI; //UI for indivitual players

	GameObject UICanvas;// the UICanvas for displaying information to the player

	// Use this for initialization
	void Start () {

		UICanvas = GameObject.Find ("UI_Canvas"); //find the games UI

		playerIndex = new List<PlayerIndex> (); // initilise list of players
		playerUI = new List<GameObject>(); //initilise list of UI for each player

		//determine how many players
		for (int i = 0; i < 4; ++i)
		{
			//load in all images
			playerUI.Add((GameObject)Instantiate(Resources.Load("UIPrefabs/PlayerUI/Imagetest")));//add ui for each player

			playerUI[i].GetComponent<RectTransform>().SetParent(UICanvas.transform);
			RectTransform gdygdy = playerUI[i].GetComponent<RectTransform>();
			playerUI[i].GetComponent<Image>().enabled = false;

			PlayerIndex testPlayerIndex = (PlayerIndex)i;
			GamePadState testState = GamePad.GetState(testPlayerIndex);
			if (testState.IsConnected)
			{
				playerIndex.Add(testPlayerIndex); //add connected players to the list
				//playerUI[i].enabled = true;
				playerUI[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(UICanvas.GetComponent<RectTransform>().rect.xMax*0.8f, 
				                                                                         UICanvas.GetComponent<RectTransform>().rect.yMax*0.8f,
				                                                                         0.0f);
				playerUI[i].GetComponent<Image>().enabled = true;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i<playerIndex.Count; ++i) {
			PlayerUI((int)playerIndex[i]);	
		}
	}

	void PlayerUI (int player) {
		switch((player+1))
		{
		case 1: break;
		case 2: break;
		case 3: break;
		case 4: break;
		default: break;
		};

	}
}

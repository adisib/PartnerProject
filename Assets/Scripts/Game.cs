//
// After Game ends, do final actions and clean up or whatever
//


using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	//

	public GameObject ball;
	public GUIText End_Text;
	public float m_fallLimit;

	private static bool m_gameOver;

	void Awake ()
	{
		// Attempt to cap framerate
		Application.targetFrameRate = 60;
		// Don't show mouse cursor

		Screen.showCursor = false;
		End_Text.text = "";
		m_gameOver = false;
	}

	// Check if fallen under platform
	void Update ()
	{
		if(ball.transform.position.y < m_fallLimit)
		{
			m_gameOver = true;
			ball.SetActive(false);
			End_Text.text = "Game Over\n Press 'R' to restart...";

			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel("Main");
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}

//
// Script from Unity Wiki, modified a bunch by me
//

using UnityEngine;
using System.Collections;

public class HUDFPS : MonoBehaviour 
{
	// It is also fairly accurate at very low FPS counts (<10).
	// We do this not by simply counting frames per interval, but
	// by accumulating FPS for each frame. This way we end up with
	// correct overall FPS even if the interval renders something like
	// 5.5 frames.
	
	public float updateInterval;
	public GUIText FPS_Text;

	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	
	private static int m_fpsPrecision = 0; // decimal places to use
	
	void Start()
	{
		if( !FPS_Text )
		{
			Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
			enabled = false;
			return;
		}
		timeleft = updateInterval;
		FPS_Text.text = "FPS: 0";
	}
	
	void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;

		if( timeleft <= 0.0 )
		{
			float fps = accum/frames;
			// FPSText.text = System.String.Format("FPS: {0:F2}",fps);
			FPS_Text.text = "FPS: " + fps.ToString("F" + m_fpsPrecision);
			
			if(fps < 40)
				FPS_Text.material.color = Color.yellow;
			else if(fps < 20)
				FPS_Text.material.color = Color.red;
			else
				FPS_Text.material.color = Color.green;
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}
	}
}
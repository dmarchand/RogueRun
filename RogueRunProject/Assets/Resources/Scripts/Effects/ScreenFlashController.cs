using UnityEngine;
using System.Collections;

public class ScreenFlashController : MonoBehaviour {

    private bool _isFlashing;
    private int _framesFlashed;
    private int _maxFrames;
    private Color _flashColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FlashScreen(Color color, int numFrames)
    {
        _flashColor = color;
        _maxFrames = numFrames;
        _framesFlashed = 0;
        _isFlashing = true;
    }

    void OnGUI()
    {
        if (_isFlashing)
        {
            if (_framesFlashed >= _maxFrames)
            {
                _isFlashing = false;
                return;
            }

            _framesFlashed++;
            GUI.color = _flashColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.guiTexture.texture, ScaleMode.StretchToFill, false);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogController : MonoBehaviour {

    [HideInInspector]
    public string CurrentLine;

    [HideInInspector]
    public List<string> LogArchive = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AppendLine(string line)
    {
        LogArchive.Add(CurrentLine);
        CurrentLine = line;
    }
}

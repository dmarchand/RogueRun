using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaneManagerController : MonoBehaviour
{

    public Dictionary<int, LaneController> lanes;

    // Use this for initialization
    void Start()
    {
        lanes = new Dictionary<int, LaneController>();
        GameObject[] laneObjects = GameObject.FindGameObjectsWithTag("Lane");

        for (int i = 0; i < laneObjects.Length; i++)
        {
            LaneController controller = laneObjects[i].GetComponent<LaneController>();
            lanes.Add(controller.laneIndex, controller);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
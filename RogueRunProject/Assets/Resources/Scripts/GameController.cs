using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] levels;

    // Use this for initialization
    void Start()
    {

        /*GameObject messenger = GameObject.Find("LevelMessageContainer");

        LevelMessageContainerController messengerController = null;
        if (messenger != null)
        {
            messengerController = messenger.GetComponent<LevelMessageContainerController>();
        }

        string levelToLoad = "Debug Land";

        if (messengerController != null)
        {
            levelToLoad = messengerController.levelName;

            Destroy(messenger);
        }

        for (int i = 0; i < levels.Length; i++)
        {
            Debug.Log(levels[i].GetComponent<LevelController>().levelSelectInfo.name);
            if (levelToLoad == levels[i].GetComponent<LevelController>().levelSelectInfo.name)
            {
                Instantiate(levels[i], new Vector3(0, 4, 1), Quaternion.identity);
                Debug.Log("Loading: " + levelToLoad);
                break;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
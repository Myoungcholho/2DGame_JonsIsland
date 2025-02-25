using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadTroStartTalk : MonoBehaviour
{
    private BadTroDialogManager manager;                   // DalogManger.cs

    void Start()
    {
        manager = GameObject.Find("BadTroDialogManager").GetComponent<BadTroDialogManager>();
        manager.endCommunication += NextScene;
        manager.Action(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
        {
            manager.Action(gameObject);
        }

    }


    // 말풍선 끝날 때 호출

    private void NextScene()
    {
        SceneManager.LoadScene("MainTitle");
    }

}

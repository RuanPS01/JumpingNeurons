using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSceneTriggerBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject firstRoomSceneSystem;

    [SerializeField]
    GameObject finishSceneSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            firstRoomSceneSystem.SetActive(false);
            finishSceneSystem.SetActive(true);
        }
    }
}

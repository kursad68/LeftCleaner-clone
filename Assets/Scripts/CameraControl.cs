using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    CharacterMovement cM;
    void Start()
    {
        cM = EventManager.onCharacterScript.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cM.transform.position.x,transform.position.y,cM.transform.position.z-15);
    }
}

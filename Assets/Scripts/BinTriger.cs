using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinTriger : MonoBehaviour
{
  
    private GameObject Barbage;
    bool isUnLoad;
    CharacterMovement cM;
    GetBarbageBox GBB;
    private void Start()
    {
        cM = EventManager.onCharacterScript.Invoke();
        GBB = EventManager.GetBarbageBoxScript.Invoke();
        Barbage = GBB.gameObject;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharacterMovement>())
        {
            if (isUnLoad == false)
            {
                StartCoroutine(unload(true));
                isUnLoad = true;
       
            }
        }
    }
    
    IEnumerator unload(bool isload)
    {
        yield return new WaitForSeconds(1f);
        unLoadBarbage();
        StartCoroutine(unload(isUnLoad));
    }
    private void unLoadBarbage()
    {
     if (cM.BarbageBoxSize >= 0)
        {
            Barbage.transform.GetChild(cM.BarbageBoxSize).gameObject.SetActive(false);
            if(cM.BarbageBoxSize!=0)
            cM.BarbageBoxSize--;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        StopAllCoroutines();
        isUnLoad = false;
      
      
    }
}

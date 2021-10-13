using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTrgider : MonoBehaviour
{
    bool isCollecting;
    public int barbageSize;
    void Start()
    {
        barbageSize = 0;
        StartCoroutine(ifCollecting(false));
    }
    IEnumerator ifCollecting(bool ifCollect)
    {
        yield return new WaitForSeconds(1f);
        if (ifCollect == true)
        {
            if (barbageSize < 3)
            {
                barbageSize++;
            }else
                if (barbageSize >= 3)
            {
                EventManager.OnBoxBarbage.Invoke();
                barbageSize = 0;
            }
        }
        StartCoroutine(ifCollecting(isCollecting));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerStay(Collider other)
    {
        ICollectable ic = other.gameObject.GetComponent<ICollectable>();
        AngryCollectable angry = other.gameObject.GetComponent<AngryCollectable>();
        if (ic != null)
        {
            isCollecting = true;
            ic.collect(true, transform.GetChild(0).gameObject);
       
        }
        else
        {
            isCollecting = false;
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ICollectable ic = other.gameObject.GetComponent<ICollectable>();
        AngryCollectable angry = other.gameObject.GetComponent<AngryCollectable>();
        if (angry != null)

        {
            ic.collect(true, transform.GetChild(0).gameObject);
            EventManager.onAngryAction.Invoke(true);
        }
        

    }

    
    private void OnTriggerExit(Collider other)
    {
       
    ICollectable ic = other.gameObject.GetComponent<ICollectable>();
    if (ic != null)
    {
            isCollecting = false;
        ic.collect(false, transform.GetChild(0).gameObject);
         
       
    }
}

}

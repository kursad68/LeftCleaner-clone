using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBarbageBox : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.GetBarbageBoxScript += GBB;
    }
    private void OnDisable()
    {
        EventManager.GetBarbageBoxScript -= GBB;
    }
    GetBarbageBox GBB()
    {
        return GetComponent<GetBarbageBox>();
    }
}

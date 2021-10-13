using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject BarbageBoxs;
    public int BarbageBoxSize;
    int BarbageBoxSizeMax;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    float zDistance;
    [SerializeField]
    private Camera maincamera;
    public int speed;

    void Start()
    {
       BarbageBoxSize = 0;
    
        BarbageBoxSizeMax = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }
    private void OnEnable()
    {
        EventManager.OnBoxBarbageUnLoad += BarbageUnLoad;
        EventManager.OnBoxBarbage.AddListener(barbageBoxCreate);
        EventManager.onCharacterScript += cM;
    }
    private void OnDisable()
    {
        EventManager.OnBoxBarbageUnLoad -= BarbageUnLoad;
        EventManager.OnBoxBarbage.RemoveListener(barbageBoxCreate);
        EventManager.onCharacterScript -= cM;
    }
    CharacterMovement cM()
    {
        return GetComponent<CharacterMovement>();
    }
    private void BarbageUnLoad(int x)
    {
        BarbageBoxSize -= x;
        if (BarbageBoxSize <= 0)
        {
            BarbageBoxSize = 0;
        }
    }
    private void barbageBoxCreate()
    {
        if (BarbageBoxSize < BarbageBoxSizeMax)
        {
            BarbageBoxs.transform.GetChild(BarbageBoxSize).gameObject.SetActive(true);

            BarbageBoxSize++;
            if(BarbageBoxSize==BarbageBoxSizeMax)
                BarbageBoxSize = BarbageBoxSizeMax - 1;
        }
        else
        {
            BarbageBoxSize = BarbageBoxSizeMax-1;
        }
    }
   

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButton(0))
        {
           Ray ray= maincamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit raycastHit))
            {
                transform.LookAt(new Vector3(raycastHit.point.x,transform.position.y,raycastHit.point.z));
                transform.position += transform.forward * Time.deltaTime * speed;
            }
             
        }
        
    }
    
}

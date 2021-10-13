using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AngryCollectable : MonoBehaviour,ICollectable
{
  
    private int Angry = 0;
    public int AngrySize;
    public bool iscollectabled;
   [SerializeField]
   private Slider slider;
    private void OnEnable()
    {
        EventManager.onAngryAction += AngrAction;
    }
    private void OnDisable()
    {
        EventManager.onAngryAction -= AngrAction;

    }

  
   
    public void collect(bool isCollactable,GameObject sourceObject)
    {
        iscollectabled = isCollactable;
        slider.value = Angry;
        if (Angry == AngrySize)
        {
            transform.DOMove(sourceObject.transform.position, 1f).OnUpdate(() =>
            {
                transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
            }).OnComplete(() => { Destroy(gameObject); transform.DOKill(); });
        }
        if (!isCollactable)
        {
           StopAllCoroutines();
            Angry = 0;
        }

    }
    private void AngrAction(bool isStartAngry)
    {
        if (isStartAngry)
            StartCoroutine(startAngry(isStartAngry));
        else
            StopAllCoroutines();
        if(slider!=null)
        slider.value = Angry;
    }
    IEnumerator startAngry(bool iscollactable)
    {
       
        yield return new WaitForSeconds(1f);
        if (iscollactable && Angry < AngrySize)
        {
            Angry++;
        }
        else
        {
            if(Angry>=AngrySize&&iscollactable) { Angry = AngrySize; }
            else
            Angry = 0;
            AngrAction(false);
        }
      
        StartCoroutine(startAngry(iscollectabled));
    }
}

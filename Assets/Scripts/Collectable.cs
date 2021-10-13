using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour,ICollectable
{
    public void collect(bool isCollectable, GameObject sourceObject)
    {

        transform.DOMove(sourceObject.transform.position, 1f).OnUpdate(() =>
        {
            transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 1f);
        }).OnComplete(() => { Destroy(gameObject); transform.DOKill(); });
    }

 
}

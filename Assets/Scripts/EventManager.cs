using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static UnityEvent OnBoxBarbage = new UnityEvent();
    public static UnityEvent isLevelFailed = new UnityEvent();
    public static UnityEvent isLevelFinish = new UnityEvent();
    public static Action<int> OnBoxBarbageUnLoad;

    public static Action<bool> onAngryAction;
    public static Func<CharacterMovement> onCharacterScript;
    public static Func<GetBarbageBox> GetBarbageBoxScript;
    public static Func<UIManager> GetUIManager;

}

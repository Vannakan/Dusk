using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Consider renaming to something like GameObjectMediator.. or MonsterMediator
public abstract class ActionMediator : MonoBehaviour
{
    public event EventHandler ActionSelected;
    public event EventHandler ActionCompleted;
    public event EventHandler OnDestroyCalled;

    public IActionBehavior CurrentAction; 
    protected MediatorState ActionState;

    //Called when ActionManager moves to next ActionResolver in the queue
    private void OnDisable()
    {
        if(CurrentAction != null)
            CurrentAction.IsActive = false;

        ActionState = MediatorState.None;
    }

    public virtual void BeginDestroy()
    {
        OnDestroyCalled?.Invoke(this, new EventArgs());
    }

    private void OnDestroy()
    {
        //ActionCompleted?.Invoke();
        OnDestroyCalled?.Invoke(this, new EventArgs());
    }

    protected void SetAction(IActionBehavior action)
    {
        if (action == null)
            return;

        if (CurrentAction != null)
            CurrentAction.IsActive = false;
        
        CurrentAction = action;
        CurrentAction.IsActive = true;

        ActionSelected?.Invoke(this, new EventArgs());

        ActionState = MediatorState.Running;
    }

    public virtual void OnActionCompleted()
    {
        ActionCompleted?.Invoke(this, new EventArgs());
        ActionState = MediatorState.Finished;
    }
}

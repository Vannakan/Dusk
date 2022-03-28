using System;
using System.Collections.Generic;
using UnityEngine;

public enum MediatorState { None, Running, Finished }

//Instead of polling in update, make everything chain.
public class ActionManager 
{
    public bool Logging = false;
    private MediatorState _currentMediatorState = MediatorState.None;

    private readonly List<ActionMediator> mediators;
    private  ActionMediator _currentMediator;
    private int _mediatorIndex = 0;

    // Start is called before the first frame update
    public ActionManager()
    {
        mediators = new List<ActionMediator>();
    }

    public void OnActionStateChange<T>(object source, EventArgs e)
    {

    }
 
    public void Update()
    {
        if (_currentMediatorState == MediatorState.Running) return;

        if (mediators.Count > 0 && _mediatorIndex < mediators.Count) 
        {
            _currentMediator = mediators[_mediatorIndex++];
            _currentMediator.enabled = true;
            _currentMediatorState = MediatorState.Running;
        }
        else
        {
            _mediatorIndex = 0;
        }
      
    }

    public void AddMediator(ActionMediator mediator)
    {
        if (mediator != null)
        {
            mediator.OnDestroyCalled += (source, args) => mediators.Remove(mediator);

            mediator.enabled = false;
            mediator.ActionCompleted += (source, args) =>
            {
                if (Logging)
                    Debug.Log("Action Manager: Received Action Completed Callback");

                mediator.enabled = false;
                _currentMediatorState = MediatorState.Finished;
            };

            mediators.Add(mediator);
        }
    }
}

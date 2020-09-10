using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IState<T>
{ 
    void Enter(T target);

    void Exit(T target);

    void HandleInput(T target);

    void Update(T target);

    void FixedUpdate(T target);
}

public class StateMachine<T>
{
    private T target;
    private IState<T> curState;
    private IState<T> prevState;

    public StateMachine()
    {
        curState = null;
        prevState = null;
    }
    public void ChangeState(IState<T> newState)
    {
        if (newState == curState)
            return;

        prevState = curState;
        
        if (curState != null)
            curState.Exit(target);

        curState = newState;

        if (curState != null)
            curState.Enter(target);
    }

    public void Init(T initTarget, IState<T> initState)
    {
        target = initTarget;
        curState = initState;
    }

    public void Update()
    {
        if (curState != null)
        {
            curState.Update(target);

            curState.HandleInput(target);
        }
    }

    public void FixedUpdate()
    {
        if (curState != null)
        {
            curState.FixedUpdate(target);

            curState.HandleInput(target);
        }
    }
    
}

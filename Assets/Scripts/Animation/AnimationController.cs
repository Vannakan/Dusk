using System;
using UnityEngine;

public class AnimationController<T> : MonoBehaviour where T : Enum
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetState(T State)
    {
        _animator.SetTrigger($"{State}");
    }
}

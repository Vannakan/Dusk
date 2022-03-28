using Assets.Scripts;
using System;
using UnityEngine;


public class StringValueAttribute : System.Attribute
{
    public string StringValue { get; protected set; }

    public StringValueAttribute(string value)
    {
        StringValue = value;
    }
}


public enum Direction { 
    [StringValue("left")]
    left = 1,
    [StringValue("right")]
    right = 2,

}

public class PlayerMovementAction : ActionBehaviour
{
    public Vector3? target;
    private Animator _animator;
   
    //Set by PlayerActionResolver;
    public float Horizontal;
    public float Vertical;
    
    void Start()
    {
        target = null;
        //just pass via ui
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!target.HasValue)
        {
            if (Mathf.Abs(Horizontal) == 1f)
            {
                SetTarget(new Vector3(Horizontal, 0f, 0f));
            }

            if (Mathf.Abs(Vertical) == 1f)
            {
                SetTarget(new Vector3(0f, Vertical, 0f));
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.Value, 5f * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.Value) == 0.0f)
            {
                OnActionCompleted();
                target = null;
            }
        }
    }

    public void SetActive(bool value) 
    {
        IsActive = value;
    }

    void SetTarget(Vector3 direction)
    {
        var newTarget = transform.position + direction;

        if (newTarget.x > transform.position.x)
        {
            _animator.SetBool("facing_right", true);
            _animator.SetTrigger("idle_right");
        }
        else if (newTarget.x < transform.position.x)
        { 
            _animator.SetBool("facing_right", false);
            _animator.SetTrigger("idle_left");
        }



        if (Map.GetTile(Vector3Int.FloorToInt(newTarget)) != null)
        {
            target = newTarget;

        }
        else
            OnActionCompleted();
    }
}

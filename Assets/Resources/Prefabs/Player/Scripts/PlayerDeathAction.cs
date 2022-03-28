using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

public class PlayerDeathAction : ActionBehaviour
{
    public Animator Animator;
    public EventHandler OnDeath;

    private void OnEnable()
    {
        // StartCoroutine(Die());
        OnActionCompleted();
    }

    private void Awake()
    {
    }

    //IEnumerator Die()
    //{
    //    //Animator.SetTrigger("death");
    //    //yield return new WaitForSeconds(2);
    //    //OnDeath?.Invoke(this, new EventArgs());
    //    //OnActionCompleted();
    //    //Destroy(gameObject);
    //}
}

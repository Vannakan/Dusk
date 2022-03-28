using Assets.Scripts;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public IntAttribute InitialHealth;
    public event EventHandler HealthChanged;
    public event EventHandler Death;
    public Animator Animator;
    public ActionMediator Mediator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Mediator = GetComponent<ActionMediator>();
    }

    private void Awake()
    {
        if(InitialHealth != null)
            HP = InitialHealth.Value;
    }

    public int HP;

    public int Value
    {
        get => HP;
        set
        {
            HP = value;

            if (HP <= 0)
                Mediator.BeginDestroy();
            else
                Animator.SetTrigger("damage");
            OnHealthChanged();
        }
    }

    //IEnumerator Die()
    //{
    //    Animator.SetTrigger("death");
    //    yield return new WaitForSeconds(2);
    //    Destroy(gameObject);
    //}

    void OnHealthChanged()
    {
        Debug.Log("HEALTH CHANGED");
        HealthChanged?.Invoke(this, new EventArgs());
    }

    void OnDeath()
    {

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
            throw new UnityException("Animator cannot be null!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("idle_right");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("idle_left");
        }
    }
}

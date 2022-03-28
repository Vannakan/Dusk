using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : ActionBehaviour
{
    public Vector3? target;

    public float Horizontal;
    public float Vertical;

    void Start()
    {
        target = null;
    }

    void Update()
    {
        if (!target.HasValue)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(horizontal) == 1f)
            {
                SetTarget(new Vector3(horizontal, 0f, 0f));
            }

            var vertical = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(vertical) == 1f)
            {
                SetTarget(new Vector3(0f, vertical, 0f));
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

    void SetTarget(Vector3 direction)
    {
        var newTarget = transform.position + direction;

        if (Map.GetTile(Vector3Int.FloorToInt(newTarget)) != null)
            target = newTarget;
    }
}

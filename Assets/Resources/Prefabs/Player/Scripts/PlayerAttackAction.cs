using Assets.Scripts;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerAttackAction : ActionBehaviour
{
    public Damage Damage;

    private float _waitTimeInSeconds = 0.3f;

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(_waitTimeInSeconds);
        var intersections = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f);
        if (intersections != null && intersections.Length > 1) //Always going to be 1 
        {
            foreach (var intersection in intersections)
            {
                if (intersection.gameObject != this.gameObject)
                {
                    var health = intersection.GetComponent<Health>();
                    health.Value -= Damage.Value.Value;
                    OnActionCompleted();
                    break;
                }
            }
        }

        OnActionCompleted();
    }
}

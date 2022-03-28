using Assets.Scripts;
using System.Collections;
using UnityEngine;

//Make generic
public class EnemyAttackAction : ActionBehaviour
{
    public Damage Damage;

    private int _damage;

    public float WaitTimeInSeconds = 0.3f;

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    private void Awake()
    {
        //Change to initialvalue
        _damage = Damage.Value.Value;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(WaitTimeInSeconds);
           
        var intersections = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f);

        if (intersections != null && intersections.Length > 1) //Always going to be 1 
        {
            foreach (var intersection in intersections)
            {
                if (intersection.gameObject.CompareTag("Player"))
                {
                    var health = intersection.GetComponent<Health>();
                    health.Value -= _damage;
                    OnActionCompleted();
                    break;
                }
            }
        }
        OnActionCompleted();
    }
}

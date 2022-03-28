using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMediator : ActionMediator
{
    public EnemyMovementAction Move;
    public EnemyAttackAction Attack;
    public EnemyDeathAction Death;
    public Tilemap Map;
    public GameObject Player;

    void Start()
    {
        //if (Move)
        //    Move.IsActive = true;

        //Move.IsActive = false;
        Move.ActionCompleted += (obj, sender) => OnActionCompleted();
        Move.Map = Map;
        Move.Player = Player;
        //Move.enabled = false;

       // Attack.IsActive = false; //These should default to inactive;
        Attack.ActionCompleted += (obj, sender) => OnActionCompleted();

        Debug.Log("START");
    }

    public override void BeginDestroy()
    {
        Death.enabled = true;
        base.BeginDestroy();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionState == MediatorState.Running) return;

        //If player is 1 tile distance away
        var distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer <= 1)
            SetAction(Attack);
        else
        SetAction(Move);
    }
}

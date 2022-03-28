using Assets.Scripts;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum PlayerActionTypes
{
    Move,Attack,Death,Slot1,Slot2,Slot3
}

public class PlayerMediator : ActionMediator
{
    //this isnt a scalable way of defining behaviour references consider building something that builds and initializes behaviours and sorts the deps out (needs ref to the gamecontroller)
    public PlayerMovementAction Move;
    public PlayerAttackAction Attack;
    public Inventory Inventory;
    public Tilemap Map;

    // Start is called before the first frame update
    void Start()
    {
        Attack.ActionCompleted += (obj, sender) => OnActionCompleted();

        Move.ActionCompleted += (obj, sender) => OnActionCompleted();
        Move.Map = Map;
    }

    public override void BeginDestroy()
    {

    }

    void Update()
    {
        if (ActionState == MediatorState.Running || !Input.anyKeyDown) return;

        HandleMovement();
        HandleAttack();
    }

    private void OnDisable()
    {
        Move.IsActive = false;
        Attack.IsActive = false;
    }

    private void HandleMovement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Move.Horizontal = horizontal;
            Move.Vertical = vertical;
            SetAction(Move);
        }
    }

    private void HandleAttack()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetAction(Attack);
        }
    }
}

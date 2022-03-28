using Assets.Scripts;
using UnityEngine;

public class EnemyMovementAction : ActionBehaviour
{
    public Vector3 targetTileCenter;
    public GameObject Player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(_animator == null)
            _animator = GetComponent<Animator>();

        SetTargetToPlayerPosition();
    }

    private void SetTargetToPlayerPosition()
    {
        if (Player)
        {         
            var playerDirection = transform.position - Player.transform.position;
            var newTarget = Vector3.zero;

            //var rightClear = methodToCheck(new Vector3(1f, 0, 0));
            //var leftClear = methodToCheck(new Vector3(-1f, 0, 0));
            //var bottomClear = methodToCheck(new Vector3(-1f, 0, 0));
            //var topClear = methodToCheck(new Vector3(0f, 1f, 0));


            if (playerDirection.x > 1)
            {
                _animator.SetTrigger("idle_left");
                _animator.SetBool("facing_right", false);
                newTarget += new Vector3(-1f, 0, 0);
            }
            if (playerDirection.x < -1)
            {
                _animator.SetTrigger("idle_right");
                _animator.SetBool("facing_right", true);
                newTarget += new Vector3(1f, 0, 0);
            }

            if (playerDirection.y >= 1 )
                newTarget += new Vector3(0f, -1f, 0);
            if (playerDirection.y <= -1)
                newTarget += new Vector3(0f, 1f, 0);

            SetTarget(transform.position + newTarget);
        }
        else
        {
            Debug.Log("Player not set");
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTileCenter, 5f * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetTileCenter) != 0f) return;

        OnActionCompleted();
    }

    private void SetTarget(Vector3 direction)
    {
        var distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer <= 1) return;

        var targetTile = Map.GetTile(Vector3Int.FloorToInt(direction));
        if (targetTile != null)
            targetTileCenter = Map.GetCellCenterWorld(Vector3Int.FloorToInt(direction));
        //Call method on class that extends Tilemap to check if occupied, if not occupied then set as target and set the tile to occupied
    }
}

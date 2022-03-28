using UnityEngine;

public class AddGold : MonoBehaviour
{
    public int Amount = 5;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            var mediator = collision.gameObject.GetComponent<PlayerMediator>();
            if (mediator != null)
            {
                //Change that gold shouldnt be so nested.. or we should make an interface for inventory adding and removing ANY items
                mediator.Inventory.Gold.Value += Amount;

                Destroy(gameObject);
            }
        }

    }
}

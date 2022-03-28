using Assets;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public Item Item;
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Item.Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            var inventory = collision.gameObject.GetComponent<PlayerMediator>();
            if (inventory != null)
            {
                inventory.Inventory.AddItem(Item);
            }

            Destroy(gameObject);
        }
    }
}

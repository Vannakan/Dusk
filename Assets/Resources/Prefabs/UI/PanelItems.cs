using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelItems : MonoBehaviour
{
    public Inventory PlayerInventory;
    public GameObject PanelItemPrefab;
    public List<GameObject> ActivePanelItems { get; set; }

    public int Columns;
    private int _counter;
    private int rows = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory.ItemAdded += (src, item) =>
        {
            var rect = GetComponent<RectTransform>();
            Debug.Log(item.Name);
            var test = Instantiate(PanelItemPrefab);
            test.GetComponent<SpriteRenderer>().sprite = item.Sprite;
            test.GetComponent<Transform>().parent = this.gameObject.transform;
            test.GetComponent<Transform>().position = GetNextPosition();


            //new Vector3(gameObject.transform.position.x + ((float)PlayerInventory.Items.All.Count/2), gameObject.transform.position.y + 1.7f , 0);
        };
    }

    private Vector3 GetNextPosition()
    {
        if (_counter >= Columns)
        {
            _counter = 0;
            rows++;
        }

        var yOffset = PlayerInventory.Items.All.Count;
        var xOffset = _counter < Columns ? ((float)_counter / 2) + .5f : .5f;
        var x = gameObject.transform.position.x + ((float)xOffset);

        Debug.Log(Mathf.Ceil(yOffset / Columns));
        var y = gameObject.transform.position.y + 2f - (0.6f * rows) ;
        _counter++;
        return new Vector3(x, y, 0);
    }
}

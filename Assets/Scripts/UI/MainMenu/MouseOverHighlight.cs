using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text Text;

    public void OnPointerEnter(PointerEventData eventData)
    {      
        Text.color = Color.white;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Text.color = Color.black;
    }

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
    }

}

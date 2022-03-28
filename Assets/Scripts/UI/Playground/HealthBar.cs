using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Health Health;

    void Start()
    {
        //TODO - link this up in the prefab
        Slider.maxValue = Health.InitialHealth.Value;
        Slider.value = Health.InitialHealth.Value;
        Health.HealthChanged += (source, args) =>
        {
            Slider.value = Health.Value;
        };
    }
}

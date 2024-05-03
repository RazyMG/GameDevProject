using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text textSliderValue;

    public void UpdateExperienceBar(float currentExp, float maxExp)
    {
        slider.value = currentExp / maxExp;
        textSliderValue.text = currentExp + "/" + maxExp;
    }
}

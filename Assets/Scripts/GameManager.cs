using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public void OnSliderUp(Slider slider)
    {
        slider.value = 0.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskShrink : MonoBehaviour {

    public RectTransform maskRect;
    public BoxCollider2D triggerCollision;
    public Image maskImage;
    public float shrinkingPeriod;
    public float minIceFieldScale;
    private float currentTime;
    Vector3 defaultScale;

	// Use this for initialization
	void Start ()
    {
        currentTime = 0.0f;
        defaultScale = maskRect.transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        float shrinkFactor = Mathf.Min(currentTime / shrinkingPeriod, 1.0f);
        Vector3 maskScale = (1.0f - shrinkFactor) * defaultScale;

        maskScale.x = Mathf.Max(maskScale.x, minIceFieldScale);
        maskScale.y = Mathf.Max(maskScale.y, minIceFieldScale);
        maskScale.z = Mathf.Max(maskScale.z, minIceFieldScale);

        maskRect.transform.localScale = maskScale;
        triggerCollision.size = new Vector2(maskScale.x * 0.93f, maskScale.y * 0.93f);
        maskImage.transform.localScale = new Vector3(1.0f / maskScale.x, 1.0f / maskScale.y, 1.0f / maskScale.z);
	}

    void resetScales()
    {
        currentTime = 0.0f;

        Vector3 maskScale = defaultScale;
        maskRect.transform.localScale = maskScale;
        triggerCollision.size = new Vector2(maskScale.x, maskScale.y);
        maskImage.transform.localScale = new Vector3(1.0f / maskScale.x, 1.0f / maskScale.y, 1.0f / maskScale.z);
    }
}

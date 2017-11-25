using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskShrink : MonoBehaviour {

    public RectTransform maskRect;
    public PolygonCollider2D triggerCollision;
    public Image maskImage;
    public GameManager gameManager;
    public float shrinkingPeriod;
    public float minIceFieldScale;
    private float currentTime;
    Vector3 defaultScale;
    Vector3 triggerCollisionDefaultScale;
    


    private void OnEnable()
    {
        gameManager.onResetEvent += this.resetScales;
    }
    private void OnDisable()
    {
        gameManager.onResetEvent -= this.resetScales;
    }


    // Use this for initialization
    void Start ()
    {
        currentTime = 0.0f;
        defaultScale = maskRect.transform.localScale;
        triggerCollisionDefaultScale = triggerCollision.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        float shrinkFactor = Mathf.Min(currentTime / shrinkingPeriod, 1.0f);
        Vector3 maskScale = (1.0f - shrinkFactor) * defaultScale;
        Vector3 collisionScale = (1.0f - shrinkFactor) * triggerCollisionDefaultScale;

        maskScale.x = Mathf.Max(maskScale.x, minIceFieldScale);
        maskScale.y = Mathf.Max(maskScale.y, minIceFieldScale);
        maskScale.z = Mathf.Max(maskScale.z, minIceFieldScale);
        collisionScale.x = Mathf.Max(collisionScale.x, 0.0001f);
        collisionScale.y = Mathf.Max(collisionScale.y, 0.0001f);
        collisionScale.z = Mathf.Max(collisionScale.z, 0.0001f);

        maskRect.transform.localScale = maskScale;
        triggerCollision.transform.localScale = collisionScale;
        maskImage.transform.localScale = new Vector3(1.0f / maskScale.x, 1.0f / maskScale.y, 1.0f / maskScale.z);
	}

    void resetScales(PlayerType playerType)
    {
        currentTime = 0.0f;

        Vector3 maskScale = defaultScale;
        maskRect.transform.localScale = maskScale;
        triggerCollision.transform.localScale = triggerCollisionDefaultScale;
        maskImage.transform.localScale = new Vector3(1.0f / maskScale.x, 1.0f / maskScale.y, 1.0f / maskScale.z);
    }
}

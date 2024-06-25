using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundUI : MonoBehaviour
{
    private Image backgroundImage;

    protected virtual void Awake()
    {
        backgroundImage = GetComponent<Image>();
        if (backgroundImage == null)
        {
            Debug.Log("BackgroundImage is null.");
            return;
        }

        SetBackground(0, true);
    }

    public virtual void SetBackground(float alpha, bool isInteractable)
    {
        if (backgroundImage != null)
        {
            Color currentColor = backgroundImage.color;
            float normalizedAlpha = alpha / 255f;
            backgroundImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, normalizedAlpha);
            backgroundImage.raycastTarget = !isInteractable;
        }
    }
}

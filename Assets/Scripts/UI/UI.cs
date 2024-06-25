using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] protected GameObject background;

    protected Image backgroundImage;

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

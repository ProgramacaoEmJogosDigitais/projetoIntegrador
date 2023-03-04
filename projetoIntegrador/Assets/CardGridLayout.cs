using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayout : LayoutGroup
{
    public int rows;
    public int columns;

    public Vector2 cardSize;
    public override void CalculateLayoutInputVertical()
    {
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;
        
        float cardHeight = parentHeight / rows;
        float cardWidth= cardHeight;

        cardSize = new Vector2(cardWidth, cardHeight);
    }

    public override void SetLayoutHorizontal()
    {
        return;
    }

    public override void SetLayoutVertical()
    {
        return;
    }
}

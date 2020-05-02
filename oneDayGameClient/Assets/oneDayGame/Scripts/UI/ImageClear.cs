using UnityEngine;
using UnityEngine.UI;

public class ImageClear : Graphic
{
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
    }
}

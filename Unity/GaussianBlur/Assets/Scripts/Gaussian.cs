using UnityEngine;
using Accord.Imaging.Filters;
using System.Collections;
using UnityEngine;
using Accord.Imaging.Filters;

public class Gaussian : MonoBehaviour
{
 
    public Renderer sourceRenderer; // our source texture is assigned on this gameobject
    public Renderer targetRenderer;

    void Start()
    {
        // get maintexture from source renderer
        var sourceTexture = (Texture2D)sourceRenderer.material.mainTexture;

        // create system bitmap
        System.Drawing.Bitmap accordImage = new System.Drawing.Bitmap(sourceTexture.width, sourceTexture.height);

        // copy our texture pixels to that system bitmap
        for (int x = 0; x < accordImage.Width; x++)
        {
            for (int y = 0; y < accordImage.Height; y++)
            {
                var c = (Color32)sourceTexture.GetPixel(x, y);
                var nc = System.Drawing.Color.FromArgb(c.r, c.g, c.b, c.a);
                accordImage.SetPixel(x, y, nc);
            }
        }


        // These 2 lines are the only Accord.NET code used here, create filter and then apply it to bitmap
        IFilter gaussianFilter = new GaussianBlur(2.0, 20);
        var resultsAccordImage = gaussianFilter.Apply(accordImage);


        // copy result pixels into our color32 array from system.drawing.bitmap
        var colors = new Color32[resultsAccordImage.Width * resultsAccordImage.Height];
        for (int x = 0; x < resultsAccordImage.Width; x++)
        {
            for (int y = 0; y < resultsAccordImage.Height; y++)
            {
                var c = resultsAccordImage.GetPixel(x, y);
                colors[y * resultsAccordImage.Width + x] = new Color32(c.A, c.R, c.G, c.B); // colors are flipped in System.Drawing.Color
            }
        }

        // create new results texture from that color32 array
        var targetTexture = new Texture2D(sourceTexture.width, sourceTexture.height, sourceTexture.format, false);
        targetTexture.SetPixels32(colors);
        targetTexture.Apply(false);

        // assign it to another object
        targetRenderer.material.mainTexture = targetTexture;
    }

}

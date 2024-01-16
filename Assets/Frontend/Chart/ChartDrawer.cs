using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChartDrawer : MonoBehaviour
{
    [SerializeField] private RawImage image;
    private Texture2D texture;

    private void Start()
    {
        int width = (int)image.rectTransform.rect.width;
        int height = (int)image.rectTransform.rect.height;

        texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        ClearTexture();

        image.texture = texture;
    }

    public void DrawChart(List<int> history, int currentPrice)
    {
        texture.filterMode = FilterMode.Point;
        
        int size = history.Count;

        float interval = texture.width / (float)(size-1);

        int max = history.Max();
        int min = history.Min();

        ClearTexture();


        for (int i = 0; i < size - 1; i++)
        {
            int next = i + 1;

            int x0 = (int)(interval * i);
            int y0 = FitPriceToHeight(min, max, history[i]);
            
            int x1 = (int)(interval * next);
            int y1 = FitPriceToHeight(min, max, history[next]);

            Color color = default;
            if (y0 > y1)
            {
                color = Color.blue;
            }
            else if(y0 < y1)
            {
                color = Color.red;
            }
            else
            {
                color = Color.black;
            }

            List<(int, int)> line = InterpolateLinePixels((x0, y0), (x1, y1));
            foreach (var pixel in line)
            {
                texture.SetPixel(pixel.Item1, pixel.Item2, color);
            }
        }

        {
            int x0 = (int)(interval * size-1);
            int y0 = FitPriceToHeight(min, max, history[size-1]);
            
            int x1 = (int)(interval * size)-1;
            int y1 = FitPriceToHeight(min, max, currentPrice);
            
            Color color = default;
            if (y0 > y1)
            {
                color = Color.blue;
            }
            else if(y0 < y1)
            {
                color = Color.red;
            }
            else
            {
                color = Color.black;
            }

            List<(int, int)> line = InterpolateLinePixels((x0, y0), (x1, y1));
            foreach (var pixel in line)
            {
                texture.SetPixel(pixel.Item1, pixel.Item2, color);
            }
        }
        
        // last
        texture.Apply();
    }

    private List<(int x, int y)> InterpolateLinePixels((int x, int y) start, (int x, int y) end)
    {
        float xPix = start.x;
        float yPix = start.y;

        float width = end.x - start.x;
        float height = end.y - start.y;
        float length = Mathf.Abs(width);

        if (Mathf.Abs(height) > length)
        {
            length = Mathf.Abs(height);
        }

        int intLength = (int)length;
        float dx = width / (float)length;
        float dy = height / (float)length;

        List<(int x, int y)> pixels = new();
        for (int i = 0; i <= intLength; i++)
        {
            pixels.Add(((int)xPix, (int)yPix));
            xPix += dx;
            yPix += dy;
        }

        return pixels;
    }

    private void ClearTexture() {
        // set white pixel
        for (int x = 0; x < texture.width; x++)
            for (int y = 0; y < texture.height; y++)
                texture.SetPixel(x, y, Color.white);
    }


    private int FitPriceToHeight(int min, int max, int price)
    {
        return (int)((price - min) / (float)(max - min) * (texture.height-1));
    }
}

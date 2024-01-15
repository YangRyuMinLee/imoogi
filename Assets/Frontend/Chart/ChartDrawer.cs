using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        texture = new Texture2D(width, height, TextureFormat.RGBA32, true);
        image.texture = texture;
    }

    public void DrawChart(List<int> history)
    {
        texture.filterMode = FilterMode.Point;

        int size = history.Count;
        int interval = texture.width / size;

        int max = history.Max();
        int min = history.Min();

        int width = (int)image.rectTransform.rect.width;
        int height = (int)image.rectTransform.rect.height;

        // set white pixel
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                texture.SetPixel(x, y, Color.white);

        for (int i = 0; i < size - 1; i++)
        {
            int next = i + 1;

            int x0 = interval * i;
            int y0 = FitPriceToHeight(min, max, history[i]);
            int x1 = interval * next;
            int y1 = FitPriceToHeight(min, max, history[next]);

            List<(int, int)> line = InterpolateLinePixels((x0, y0), (x1, y1));
            foreach (var pixel in line)
            {
                DrawBigPixel(pixel.Item1, pixel.Item2, Color.black);
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

    private int FitPriceToHeight(int min, int max, int price)
    {
        return (int)((price - min) / (float)(max - min) * image.rectTransform.rect.height);
    }

    private void DrawBigPixel(int x, int y, Color color)
    {
        int width = (int)image.rectTransform.rect.width;
        int height = (int)image.rectTransform.rect.height;

        texture.SetPixel(x, y, Color.black);
        texture.SetPixel(x, y - 1, Color.black);

        texture.SetPixel(x + 1, y, Color.black);
        texture.SetPixel(x + 1, y - 1, Color.black);
    }
}
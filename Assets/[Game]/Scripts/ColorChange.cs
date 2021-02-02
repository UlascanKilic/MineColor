using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    [SerializeField]
    public List<Material> colors;
    public List<Material> tempColors;

    [SerializeField]
    public List<Transform> lanes;
    public List<Transform> tempLanes;

    [SerializeField]
    int cooldown;

    int colorIndex, railIndex;
    Renderer renderer;
    private Material ChoosenColor;

    void Start()
    {
        StartCoroutine(ShuffleColor(cooldown));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShuffleColor(int cooldown)
    {
        while (true)
        {

            for (int i = 0; i < 3; i++)
            {
                colorIndex = Random.Range(0, tempColors.Count);


                if (tempColors.Count != 1)
                {
                    ChoosenColor = tempColors[colorIndex];
                    tempColors.RemoveAt(colorIndex);

                }
                else
                {
                    ChoosenColor = tempColors[0];
                    tempColors.RemoveAt(0);

                }

                railIndex = Random.Range(0, tempLanes.Count);


                if (tempLanes.Count != 1)
                {

                    foreach (Transform child in tempLanes[railIndex])
                    {
                        renderer = child.GetComponent<Renderer>();
                        renderer.enabled = true;
                        renderer.sharedMaterial = ChoosenColor;
                    }

                    tempLanes.RemoveAt(railIndex);
                }
                else
                {

                    foreach (Transform child in tempLanes[0])
                    {
                        renderer = child.GetComponent<Renderer>();
                        renderer.enabled = true;
                        renderer.sharedMaterial = ChoosenColor;
                    }
                    tempLanes.RemoveAt(0);
                }
            }
            tempColors.Clear();

            tempLanes.Clear();

            for (int k = 0; k < 3; k++)
            {
                tempColors.Add(colors[k]);

                tempLanes.Add(lanes[k]);
            }
            colorIndex = -1;
            railIndex = -1;
            yield return new WaitForSeconds(cooldown);
        }

    }
}

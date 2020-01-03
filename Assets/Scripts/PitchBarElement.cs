using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitchBarElement : MonoBehaviour
{
    Color normalColor = Color.white;
    Color highlightColor = Color.green;


    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        if (img == null)
            img = gameObject.AddComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HighLight(bool hightlight)
    {
        if (hightlight)
            img.color = highlightColor;
        else
            img.color = normalColor;
    }
}

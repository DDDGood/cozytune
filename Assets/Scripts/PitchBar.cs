using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchBar : MonoBehaviour
{


    int currentIndex = -1;
    PitchBarElement[] elements;
    // Start is called before the first frame update
    void Start()
    {
        elements = GetComponentsInChildren<PitchBarElement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHightLight(float value)
    {
        value = Mathf.Clamp01(value);
        float fixValue = Mathf.Lerp(0, elements.Length - 1, value / 1);
        int index = Mathf.RoundToInt(fixValue);

        if (currentIndex > -1)
            elements[currentIndex].HighLight(false);

        elements[index].HighLight(true);

        currentIndex = index;
    }

    public void Reset()
    {
        if (currentIndex > -1)
            elements[currentIndex].HighLight(false);

        currentIndex = -1;
    }



}

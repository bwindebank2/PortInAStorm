using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] private int endTime = 3;
    [SerializeField] private GameObject crossFade;

    public void FadeOut()
    {
        crossFade.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        crossFade.GetComponent<Animator>().SetTrigger("FadeIn");
    }

}

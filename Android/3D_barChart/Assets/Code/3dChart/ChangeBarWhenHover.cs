using UnityEngine;
using System.Collections;

public class ChangeBarWhenHover : MonoBehaviour {


    Color colorOn = Color.gray;
    Color colorOff = Color.white;
    float duration = 0.6f;

    float t;
    bool turnOn;
    bool turnOff;

    private Renderer renderer;

void Start()
    {
        GetComponent<Renderer>().material.color = colorOff;

        renderer = GetComponent<Renderer>();
        //normal = Shader.Find("Standard");
        //hover = Shader.Find("FX/Gem");
    }

void OnMouseEnter()
    {

        turnOn= true;
        turnOff = false;
        t = duration;
        StartCoroutine (turnItOn());

        //        GetComponent<Renderer>().material.color = Color.gray;

    }

void OnMouseExit()
    {
        turnOn = false;
        turnOff = true;
        t = duration;
        StartCoroutine (turnItOff());
        //GetComponent<Renderer>().material.color = Color.white;
    }

IEnumerator turnItOn() {
        while (t > 0 && turnOn)
        {
            //print(t + " Fade in" + " Fade out");
            renderer.material.color = Color.Lerp(colorOn, colorOff, t);
            t -= Time.deltaTime / duration;
            //Debug.Log("Color oning: " + renderer.material.color);
            yield return 0;
        }

        turnOn = false;
    }

IEnumerator turnItOff()
    {
        while (t > 0 && turnOff)
        {
            //print(t + " Fade in" + " Fade out");
            renderer.material.color = Color.Lerp(colorOff, colorOn, t);
            t -= Time.deltaTime / duration;
            //Debug.Log("Color offing: " + renderer.material.color);
            yield return 0;
        }

        turnOff = false;
    }

}

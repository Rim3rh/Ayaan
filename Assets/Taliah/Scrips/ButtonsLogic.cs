using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLogic : MonoBehaviour
{
    [Header("GUIA USO")]
    [Tooltip("En el button arrastras el button, y el collider es lo que hace que se active el boton, por lo que hay q ponerlo cunado queramos q se active el boton")]
    [SerializeField] Button button;
    [SerializeField] GameObject arte;
    [SerializeField] GameObject rotate1, rotate2;
    void Start()
    {
       // button = GetComponent<Button>();
        button.interactable = false;
    }
    private void FixedUpdate()
    {
        rotate1.transform.Rotate(0, 0, 1);
        rotate2.transform.Rotate(0,0,-1);
    }

    public void SetToDisabled()
    {
        button.interactable = false;
        arte.GetComponent<Animator>().Play("BoostFadeOut");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            arte.GetComponent<Animator>().Play("GrayToWhite");
            button.interactable = true;
        }
    }
}

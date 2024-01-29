using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HudBlendIn : MonoBehaviour
{

    [SerializeField] GameObject[] hudItems;
    void Start()
    {

        StartCoroutine(enter());
       //hudItems[0].GetComponent<Image>().CrossFadeAlpha(0, 5f, false);
       // hudItems[1].GetComponent<Image>().CrossFadeAlpha(1.0f, 5f, false);
        //hudItems[2].GetComponent<TextMeshProUGUI>().CrossFadeAlpha(1.0f, 5f, false); 
    }

    private IEnumerator enter()
    {
        for (int i = 0; i < hudItems.Length; i++) 
        {
            Image imageComponent = hudItems[i].GetComponent<Image>();
            Color imageColor = imageComponent.color;
            imageColor.a = 0.0f;
            for (int j = 0; j < 100; j++)
            {
                imageComponent.color = imageColor;
                imageColor.a =+ 0.01f;
                
                yield return new WaitForSeconds(0.05f);
            }



            
        }
    }
}

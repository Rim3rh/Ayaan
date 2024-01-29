using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DethScene : MonoBehaviour
{

    [SerializeField] DistanceCalculator distanceCalculator;

    public static int gemCounter;
    public static int pointsC;


    [SerializeField] TextMeshProUGUI distance, pointsT, stones;


    public void SetValues()
    {
        distance.text = ("Distance:" + "   " + distanceCalculator.distance.ToString());
        pointsT.text = ("Points:" + "   " + DethScene.pointsC.ToString());
    }
}

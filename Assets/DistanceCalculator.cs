using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    public float distance;
   // public int points;


     private Vector2 startPos;
    [SerializeField] private Transform player;
    private GameObject playerPS;
    [SerializeField] private TextMeshProUGUI text;
     private TextMeshProUGUI pointsT;
    void Start()
    {
        
        playerPS = GameObject.Find("ParticleSystems");
       //pointsT.text = "0";
        if (player != null) startPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (GameObject.Find("PointsText") != null) pointsT = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
        if (player != null) distance = Mathf.RoundToInt(Vector3.Distance(startPos, player.transform.position) / 6);
    }



    public void AddPoints(int pointsA)
    {
        DethScene.pointsC += pointsA;
        pointsT.text = DethScene.pointsC.ToString();
        playerPS.transform.Find("+" + pointsA).GetComponent<ParticleSystem>().Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name != "--Player--")
        {
            SoundManager.Instance.CoinSound();
            DethScene.pointsC += 10;
            pointsT.text = DethScene.pointsC.ToString();
            playerPS.transform.Find("+10").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }

    }
}


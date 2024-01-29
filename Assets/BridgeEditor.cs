using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeEditor : MonoBehaviour
{

    [SerializeField] Transform pos1, pos2, newRock;
    [SerializeField] GameObject stonePrefab, stone1;

    GameObject newStone;
    Transform childTransform;
    private void Start()
    {
       // StartCoroutine(BuildBridge());
    }


    public void start()
    {
        StartCoroutine(BuildBridge());
    }
    public IEnumerator BuildBridge()
    {
        SoundManager.Instance.Rebuild();
        int distance;
        int numberOfStones;
        distance = Mathf.RoundToInt(Vector3.Distance(pos1.position, pos2.position));
        numberOfStones = distance / 4;

        yield return new WaitForSeconds(0.15f);

        Debug.Log(stonePrefab);
        Debug.Log(newRock);
        Debug.Log(newStone);
        Debug.Log(stone1);
        newStone = Instantiate(stonePrefab, newRock.position, stonePrefab.transform.rotation = Quaternion.Euler(0, 0, stone1.transform.rotation.eulerAngles.z));

        childTransform = newStone.transform.Find("TransformNewRock");
        yield return new WaitForSeconds(0.06f);
        for (int i = 0; i < numberOfStones -1; i++)
        {
            //Euler(stonePrefab.transform.rotation.x, stonePrefab.transform.rotation.y, stone1.transform.rotation.z)
            newStone = Instantiate(stonePrefab, childTransform.position, newStone.transform.rotation = Quaternion.Euler(stonePrefab.transform.rotation.x, stonePrefab.transform.rotation.x, stone1.transform.rotation.eulerAngles.z));
                childTransform = newStone.transform.Find("TransformNewRock");

            yield return new WaitForSeconds(0.15f);
        }
        
        
    }
}

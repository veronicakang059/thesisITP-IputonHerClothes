using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Vuforia;

public class SpawnBubbles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnBubbles;
    public GameObject virtualButton;
    private static int bubbles;
    private bool outOfBubbles;
    //public Vector3 bubblePosition;
    
    void Start()
    {
        bubbles = 0;
        outOfBubbles = false;
        virtualButton = GameObject.Find("Tap");
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed);
    }

    // Update is called once per frame

    void onButtonPressed(VirtualButtonBehaviour vb)
    {
        var bubblePosition = new Vector3(Random.Range(-0.2f, 0.2f), 0.001f, Random.Range(-0.3f, 0.3f));
        var bubbleRotation = Quaternion.Euler(0, 180, 0);
        if (!outOfBubbles)
        {
            Instantiate(spawnBubbles, bubblePosition,bubbleRotation);
            bubbles++;
        }
    }
    void Update()
    {
        if (bubbles > 6)
        {
            outOfBubbles = true;
            virtualButton.SetActive(false);
        }
        else
        {
            virtualButton.SetActive(true);
        }
        
    }
}

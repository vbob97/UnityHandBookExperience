using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public delegate void SwipeAction(string direction);
    public static event SwipeAction OnSwipe;
    private float swipeDebounceTime = 0.5f; // Tempo in secondi
    private float lastSwipeTime = 0;
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    private Vector3 previousIndexTipPosition;
    private bool hasPreviousPosition = false;

    void Update()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        for (int i = 0; i < 21; i++)
        {
            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }

        DetectSwipe();
    }

    void DetectSwipe()
    {
        Vector3 currentIndexTipPosition = handPoints[8].transform.localPosition; // Punto 8 è la punta dell'indice

        if (hasPreviousPosition && Time.time - lastSwipeTime > swipeDebounceTime)
        {
            Vector3 movementDirection = currentIndexTipPosition - previousIndexTipPosition;
            if (movementDirection.x > 0.5) // Soglia per rilevare un movimento a destra
            {
                lastSwipeTime = Time.time;
                Debug.Log("Destra");
                OnSwipe?.Invoke("Destra");

            }
            else if (movementDirection.x < -0.5) // Soglia per rilevare un movimento a sinistra
            {
                 lastSwipeTime = Time.time;
                 Debug.Log("Sinistra");
                 OnSwipe?.Invoke("Sinistra");
            }
        }

        previousIndexTipPosition = currentIndexTipPosition;
        hasPreviousPosition = true;
    }
}
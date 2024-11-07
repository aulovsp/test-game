using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingManager : MonoBehaviour
{
    public int maxPoints;
    public Text score;

    private int points;

    void Start()
    {
        points = 0;
        score.text = $"{points}/{maxPoints}";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (points >= maxPoints)
            {
                return;
            }

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit))
            {
                return;
            }

            var collectable = hit.collider.GetComponent<Collectable>();

            if (collectable == null)
            {
                return;
            }

            collectable.Collect();
            points++;
            score.text = $"{points}/{maxPoints}";
        }
    }

    public bool IsTaskComplete()
    {
        return points >= maxPoints;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Horse
{
    public GameObject target;
    public float Speed;
}

public class Horsemove : MonoBehaviour
{
    public List<Horse> hObjects = new List<Horse>();
    private float minSpeed;
    private float maxSpeed;

    private void Awake()
    {
        foreach (var h in hObjects)
        {
            minSpeed = h.Speed / UnityEngine.Random.Range(8f, 20f) - UnityEngine.Random.Range(0.1f, 5f);
            maxSpeed = h.Speed * UnityEngine.Random.Range(16f, 20f) + UnityEngine.Random.Range(0.1f, 5f);
        }
    }

    void Update()
    {
        foreach (var h in hObjects)
        {
            if(h.target != null)
            {
                Vector2 targetPosition = new Vector2(h.target.transform.position.x + 0.1f, h.target.transform.position.y);
                h.target.transform.position = Vector2.MoveTowards(h.target.transform.position, targetPosition, h.Speed * Time.deltaTime);

                float positionThreshold = 0.01f;

                if (Mathf.Abs(h.target.transform.position.x - transform.position.x) < positionThreshold)
                {
                    gameObject.GetComponent<Horsemove>().enabled = false;
                }


                float range = UnityEngine.Random.Range(0.1f, 1f);//10% ~ 100%

                if (UnityEngine.Random.Range(0f, 1f) < range)
                    h.Speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
            }
        }
    }
}

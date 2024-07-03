using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame2
{
    public class Cintamani : MonoBehaviour
    {
        [SerializeField] private int minMultiplier;
        [SerializeField] private int maxMultiplier;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                MingameData.Instance.currentMultiplier = UnityEngine.Random.Range(minMultiplier, maxMultiplier);
                Destroy(gameObject);
            }
        }
    }
}
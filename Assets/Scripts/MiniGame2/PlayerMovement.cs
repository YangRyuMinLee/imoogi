using System;
using UnityEngine;

namespace Minigame2
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Config")] [SerializeField] private float pushForce = 1;

        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
            }
        }

        public void Die()
        {
            // 카메라 흔들림
            CameraManager.Instance.Shake(0.2f, 0.1f);

            // 원래 위치로
            transform.position = new Vector2(0, 0);

            // 배수를 0으로
            MingameData.Instance.currentMultiplier = 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                Debug.Log("Died");
                Die();
            }
        }

        public void StartMovement()
        {
            if (!rb) return;
            
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        public void StopMovement()
        {
            if (!rb) return;

            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
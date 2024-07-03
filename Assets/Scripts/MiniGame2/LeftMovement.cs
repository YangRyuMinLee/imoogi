using UnityEngine;

namespace Minigame2
{
    public class LeftMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        void Update()
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}

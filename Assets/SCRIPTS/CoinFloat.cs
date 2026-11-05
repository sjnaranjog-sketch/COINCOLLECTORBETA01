
using UnityEngine;

public class CoinFloat : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float height = 0.5f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float movement = Mathf.PingPong(
            Time.time * speed, height * 2f
        ) - height;

        transform.position = startPosition +
            Vector3.up * movement;
    }
}

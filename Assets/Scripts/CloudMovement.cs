using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < Camera.main.transform.position.x - 20f)
        {
            Destroy(gameObject);
        }
    }
}
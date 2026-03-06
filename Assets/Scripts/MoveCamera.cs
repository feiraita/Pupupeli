using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void LateUpdate()
    {
        transform.position = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y + 2,
            transform.position.z
        );
    }
}
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void LateUpdate()
    {
        transform.position = new Vector3(
            0,
            playerTransform.position.y + 1,
            transform.position.z
        );
    }
}
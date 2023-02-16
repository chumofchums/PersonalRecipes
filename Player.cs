using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed = 5f;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}

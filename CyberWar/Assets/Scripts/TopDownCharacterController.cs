using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        // Move the character
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector3 direction)
    {
        // Update the character's position based on the input
        transform.position += direction * speed * Time.deltaTime;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust this to control the movement speed
    public float maxXPosition = 0f; // Set the maximum X position within the player's half
    public float minXPosition = -5f; // Set the minimum X position within the player's half
    public float maxYPosition = 5f; // Set the maximum Y position within the player's half
    public float minYPosition = -5f; // Set the minimum Y position within the player's half

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get input values for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal"); // Assumes each player's GameObject has a unique tag
        float verticalInput = Input.GetAxis("Vertical");     // Assumes each player's GameObject has a unique tag

        // Calculate movement direction
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Calculate movement amount
        Vector2 movementAmount = moveDirection * movementSpeed * Time.fixedDeltaTime;

        // Calculate new position after movement
        Vector2 newPosition = rb2d.position + movementAmount;

        // Limit movement within the player's half
        newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
        newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition);

        // Move the player using Rigidbody2D
        rb2d.MovePosition(newPosition);
    }
}

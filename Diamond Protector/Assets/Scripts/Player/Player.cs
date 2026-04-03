using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [Header("Input Settings")]
    [SerializeField] private float moveInputX;
    [SerializeField] private float moveInputY;
    [SerializeField] private Vector2 mousePos;

    private void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Move();

        MouseLook();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveInputX * speed, moveInputY * speed);    
    }

    private void MouseLook()
    {
        mousePos = mousePos - rb.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
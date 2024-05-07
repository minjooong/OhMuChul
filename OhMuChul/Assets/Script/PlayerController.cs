using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // 플레이어의 이동 속도
    public float jumpForce = 10f; // 플레이어의 점프 힘
    public Transform groundCheck; // 바닥 체크를 위한 오브젝트의 위치
    public LayerMask groundLayer; // 바닥의 레이어

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 키보드 입력을 통해 플레이어를 움직임
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 바닥 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 점프
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

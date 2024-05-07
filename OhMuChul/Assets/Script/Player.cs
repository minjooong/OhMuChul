using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 12f; // 플레이어의 이동 속도
    public float jumpForce = 15f; // 플레이어의 점프 힘
    public Transform groundCheck; // 바닥 체크를 위한 오브젝트의 위치
    public LayerMask groundLayer; // 바닥의 레이어

    private Rigidbody2D rb;
    public Vector2 moveInput; // Vector2
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 키보드 입력을 통해 플레이어를 움직임
        moveInput.x = Input.GetAxisRaw("Horizontal"); // x값만 설정

        // 바닥 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 점프
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate에서 rigidbody에 속도를 적용
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }
}

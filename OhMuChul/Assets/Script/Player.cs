using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 12f; // 플레이어의 이동 속도
    public float jumpForce = 15f; // 플레이어의 점프 힘
    public Transform groundCheck; // 바닥 체크를 위한 오브젝트의 위치
    public LayerMask groundLayer; // 바닥의 레이어
    public Transform speechBubble; // 말풍선 Transform


    private Rigidbody2D rb;
    private Animator animator; // 애니메이터
    public Vector2 moveInput; // Vector2
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // 애니메이터 초기화
    }
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // 애니메이터의 Speed 파라미터 설정
        moveInput.x = Input.GetAxisRaw("Horizontal"); // x값만 설정
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));

        // 말풍선 이미지 위치 업데이트
        UpdateSpeechBubblePosition();

       

    }



    private void FixedUpdate()
    {
        // 키보드 입력을 통해 플레이어를 움직임
        moveInput.x = Input.GetAxisRaw("Horizontal"); // x값만 설정
        // FixedUpdate에서 rigidbody에 속도를 적용
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        // 카메라 시야 영역
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // 플레이어의 위치 제한
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }

    private void UpdateSpeechBubblePosition()
    {
        // 말풍선 위치를 플레이어 머리 옆으로 설정
        if (speechBubble != null)
        {
            Vector3 bubblePosition = transform.position + new Vector3(-2, 1, 0); // 적절한 위치로 조정
            speechBubble.position = bubblePosition;
        }

    }



    public void EnableProtection()
    {
        // 플레이어를 보호하는 동작을 여기에 추가
        // 예를 들어, 보호 상태를 활성화하거나 효과음을 재생할 수 있습니다.
        // 이 메서드를 호출하는 것은 아이템 스크립트에서 수행됩니다.
    }
}


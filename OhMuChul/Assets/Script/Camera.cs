using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform

    // 카메라와 플레이어 간의 거리
    public Vector3 offset = new Vector3(4f, 0f, -10f);

    // 카메라의 이동 속도
    public float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        // 플레이어의 현재 위치에 offset을 더하여 카메라의 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // y축 값 고정
        desiredPosition.y = transform.position.y;

        // 카메라가 왼쪽으로 이동하지 않도록 함
        desiredPosition.x = Mathf.Max(transform.position.x, desiredPosition.x);

        // 카메라의 위치를 부드럽게 조정
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라의 위치를 목표 위치로 설정
        transform.position = smoothedPosition;
    }
}

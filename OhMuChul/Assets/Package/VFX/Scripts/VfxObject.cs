using UnityEngine;

/// <summary>
/// VFX Object 관련 처리 컴포넌트
/// </summary>
public class VfxObject : MonoBehaviour
{
    private ParticleSystem particle;
    private void Awake() { particle = GetComponent<ParticleSystem>(); }

    void Update()
    {
        if (particle == null)
            return;

        if (particle.isStopped)
            Destroy(this.gameObject);
    }
}

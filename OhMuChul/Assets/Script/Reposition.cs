using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Area"))
        {
            return;
        }
        // Vector3 playerPos = GameManager.instance.player.transform.position;
        // Vector3 myPos = transform.position;
        // float diffx = Mathf.Abs(playerPos.x - myPos.x);

        Player playerScript = GameManager.instance.player.GetComponent<Player>();
        Vector2 playerDir = playerScript.moveInput;
        float dirx = playerDir.x < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                transform.Translate(Vector3.right * dirx * 72);
                break;
            case "Sky":
                transform.Translate(Vector3.right * dirx * 72);
                break;
        }
    }
}

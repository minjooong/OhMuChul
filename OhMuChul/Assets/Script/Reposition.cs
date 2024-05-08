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
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        // float diffy = Mathf.Abs(playerPos.y - myPos.y);
        Debug.Log(playerPos);
        Debug.Log(myPos);
        Debug.Log(diffx);

        Player playerScript = GameManager.instance.player.GetComponent<Player>();
        Vector2 playerDir = playerScript.moveInput;
        float dirx = playerDir.x < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffx > 32)
                {
                    transform.Translate(Vector3.right * dirx * 64);

                }
                break;
            case "Sky":
                if (diffx > 16)
                {
                    transform.Translate(Vector3.right * dirx * 64);
                }
                break;
            case "Enemy": break;

        }
    }
}

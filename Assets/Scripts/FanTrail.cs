using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FanTrail : MonoBehaviour
{
    public float speed = 5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TarodevController.PlayerController>())
        {
            TarodevController.PlayerController controller = collision.gameObject.GetComponent<TarodevController.PlayerController>();
            controller.offset = transform.rotation * new Vector2(0, speed);
            controller.gravity = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TarodevController.PlayerController>())
        {
            TarodevController.PlayerController controller = collision.gameObject.GetComponent<TarodevController.PlayerController>();
            controller.offset = Vector2.zero;
            controller.gravity = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Vector3 leftDown = transform.position + transform.rotation * new Vector3(-transform.lossyScale.x * 0.5f, -transform.lossyScale.y * 0.5f);
        Vector3 leftUp = transform.position + transform.rotation * new Vector3(-transform.lossyScale.x * 0.5f, transform.lossyScale.y * 0.5f);
        Vector3 rightDown = transform.position + transform.rotation * new Vector3(transform.lossyScale.x * 0.5f, -transform.lossyScale.y * 0.5f);
        Vector3 rightUp = transform.position + transform.rotation * new Vector3(transform.lossyScale.x * 0.5f, transform.lossyScale.y * 0.5f);

        Gizmos.DrawLine(leftDown, leftUp);
        Gizmos.DrawLine(rightDown, rightUp);
        Gizmos.DrawLine(leftUp, rightUp);

        Gizmos.color = Color.green;
        Vector3 halfUp = transform.position + transform.rotation * new Vector3(-transform.lossyScale.x * 0, transform.lossyScale.y * 0.5f);
        Gizmos.DrawLine(rightDown, leftDown);
        Gizmos.DrawLine(leftDown, halfUp);
        Gizmos.DrawLine(rightDown, halfUp);
    }
}

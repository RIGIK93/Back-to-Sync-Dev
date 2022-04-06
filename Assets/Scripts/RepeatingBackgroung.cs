using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgroung : MonoBehaviour
{
    [SerializeField] private Vector2 multiplier;
    [SerializeField] private bool isRepeating = true;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float TextureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        if (!isRepeating) return;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        TextureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaCamera = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaCamera.x * multiplier.x, deltaCamera.y * multiplier.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;

        if (!isRepeating) return;
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= TextureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % TextureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y, transform.position.z);
        }
    }
}

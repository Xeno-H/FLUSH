using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomSignController : MonoBehaviour
{
    public GameObject FBROOM;
    public GameObject MBROOM;
    public float jumpHeight = 1.0f; // Height of the jump
    public float jumpDuration = 0.2f; // Duration of the jump

    private bool isJumpingFBROOM = false;
    private bool isJumpingMBROOM = false;

    void Update()
    {
        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isJumpingMBROOM)
        {
            StartCoroutine(Jump(MBROOM));
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isJumpingFBROOM)
        {
            StartCoroutine(Jump(FBROOM));
        }
    }

    IEnumerator Jump(GameObject broom)
    {
        bool isJumping = broom == FBROOM ? isJumpingFBROOM : isJumpingMBROOM;
        if (isJumping) yield break;

        // Set jumping flag
        if (broom == FBROOM) isJumpingFBROOM = true;
        if (broom == MBROOM) isJumpingMBROOM = true;

        Vector3 originalPosition = broom.transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(0, jumpHeight, 0);

        // Move up
        float elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            broom.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / jumpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        broom.transform.position = targetPosition;

        // Move back down
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            broom.transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / jumpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        broom.transform.position = originalPosition;

        // Reset jumping flag
        if (broom == FBROOM) isJumpingFBROOM = false;
        if (broom == MBROOM) isJumpingMBROOM = false;
    }
}
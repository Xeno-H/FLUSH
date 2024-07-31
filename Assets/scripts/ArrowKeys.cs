using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeys : MonoBehaviour
{
    public GameObject RARROW;
    public GameObject LARROW;
    
    void Update()
    {
        // Check for left arrow key press
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(HideAndShow(LARROW));
        }

        // Check for right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(HideAndShow(RARROW));
        }
    }

    IEnumerator HideAndShow(GameObject arrow)
    {
        // Disable the arrow
        arrow.SetActive(false);

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.1f);

        // Enable the arrow
        arrow.SetActive(true);
    }
}
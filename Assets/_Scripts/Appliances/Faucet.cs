using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    private bool m_CanInteract;
    public GameObject resourceCanvas;
    public GameObject interactableCanvas;
    public static bool isFixed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_CanInteract && !isFixed)
        {
            //m_Puzzle.SetActive(true);
            GetComponent<InstantiatePuzzle>().InstantiatePuzzleType();
            resourceCanvas.GetComponent<Canvas>().enabled = false;
            interactableCanvas.GetComponent<Canvas>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && !isFixed)
        {
            UIManager.Instance.ShowInteractUI(true);
            m_CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) && !isFixed)
        {
            UIManager.Instance.ShowInteractUI(false);
            m_CanInteract = false;
        }
    }
}
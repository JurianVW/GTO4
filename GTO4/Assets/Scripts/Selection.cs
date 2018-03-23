using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    Tile currentSelection;
    Tile moveSelection;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (currentSelection == null)
                {
                    currentSelection = hit.collider.GetComponentInParent<Tile>();
                    OnCurrentSelection();
                }
                else if (moveSelection == null)
                {
                    moveSelection = hit.collider.GetComponentInParent<Tile>();
                    OnMoveSelection();
                }
            }
            else
            {
                if (currentSelection != null)
                {
                    DeselectAll();
                }
            }
        }
    }

    private void OnCurrentSelection()
    {
        if (currentSelection.unit != null)
        {
            currentSelection.transform.GetComponent<Selectable>().Select();
            Debug.Log("Select");
        }
        else
        {
            currentSelection = null;
        }
    }

    private void OnMoveSelection()
    {
        if (!moveSelection.occupied)
        {
            Debug.Log("MoveSelection");
            currentSelection.unit.Move(moveSelection);
            DeselectAll();
        }

    }

    private void DeselectAll()
    {
        if (currentSelection != null) currentSelection.transform.GetComponent<Selectable>().Deselect();
        if (moveSelection != null) moveSelection.transform.GetComponent<Selectable>().Deselect();
        currentSelection = null;
        moveSelection = null;
    }
}

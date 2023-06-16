using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector3 lastPos;

    public bool isPainting;

    private void Update()
    {
        if (isPainting)
            Drawing();

    }

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        RaycastHit hit;
        Vector3 mousePos = Vector3.zero;

        //because you gotta have 2 points to start a line renderer, 
        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            mousePos = hit.point;
        }
           // Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector3 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {

        RaycastHit hit;
        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Vector3 mousePos = hit.point;
            if (lastPos != mousePos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }

    }

}


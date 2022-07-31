using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Joint _dragJoint;
    [Space]
    [SerializeField] private LayerMask _mask;

    private Transform _dragAnchorTransform;
    private PlayerState _state;
    

    private void Awake()
    {
        _dragAnchorTransform = _dragJoint.transform;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _state = PlayerState.Clicked;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            _dragJoint.connectedBody = null;
            _state = PlayerState.None;
        }
        if (_state == PlayerState.Dragging)
        {
            ConverMousePositionToWorlPoint();
        }

    }
    private void FixedUpdate()
    {
        if (_state == PlayerState.Clicked) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 50, _mask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.collider.TryGetComponent(out Rigidbody rb))
                {
                    _dragJoint.connectedBody = rb;
                    _state = PlayerState.Dragging;
                }
                else 
                {
                    _state = PlayerState.AfterClick;
                }
            }
        }
    }
    private void ConverMousePositionToWorlPoint() 
    {
        Vector3 worldPos = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
        if(worldPos.y < 0) 
        {
            worldPos = new Vector3(worldPos.x, 0, worldPos.z);
        }
        _dragAnchorTransform.position = worldPos;
    }
}

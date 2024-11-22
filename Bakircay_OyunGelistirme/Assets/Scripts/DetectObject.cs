using System;
using UnityEngine;
using Common;

public class DetectObject : MonoBehaviour
{
    private Camera _mainCamera;
    private Rigidbody _selectedRigidbody = null;
    private Vector3 _accumulatedForce = Vector3.zero;
    private float _forceMultiplier = 7f;

    private void Start()
    {
        _mainCamera = Camera.main;

        TouchManager.Instance.OnMouseDown += OnMouseDown;
        TouchManager.Instance.OnMouseDrag += OnMouseDrag;
        TouchManager.Instance.OnMouseUp += OnMouseUp;
    }

    private void OnDestroy()
    {
        if (TouchManager.Instance == null)
            return;

        TouchManager.Instance.OnMouseDown -= OnMouseDown;
        TouchManager.Instance.OnMouseDrag -= OnMouseDrag;
        TouchManager.Instance.OnMouseUp -= OnMouseUp;
    }

    private void OnMouseDown(MouseData data)
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(data.position);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit object: " + hit.transform.name);

            if (hit.rigidbody != null)
            {
                _selectedRigidbody = hit.rigidbody;
            }
        }
    }

    private void OnMouseDrag(MouseData data)
    {
        if (_selectedRigidbody != null)
        {
            _accumulatedForce += new Vector3(data.deltaPosition.x, 1f, data.deltaPosition.y) * Time.deltaTime;
        }
    }

    private void OnMouseUp(MouseData data)
    {
        _selectedRigidbody = null;
        _accumulatedForce = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (_selectedRigidbody != null)
        {
            _selectedRigidbody.AddForce(_accumulatedForce * _forceMultiplier, ForceMode.Impulse);
            _accumulatedForce = Vector3.zero;
        }
    }
}

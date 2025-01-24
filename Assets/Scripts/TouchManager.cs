using System;
using UnityEngine;

namespace Common
{
    public struct MouseData
    {
        public bool hasValue;
        public Vector2 position;
        public Vector2 deltaPosition;
    }

    public class TouchManager : MonoBehaviour
    {
        private static TouchManager _instance;
        public static TouchManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TouchManager>();
                }
                if (_instance == null)
                {
                    Debug.LogError("TouchManager not found in scene");
                }
                return _instance;
            }
        }

        public Action<MouseData> OnMouseDown;
        public Action<MouseData> OnMouseDrag;
        public Action<MouseData> OnMouseUp;

        private MouseData _currentMouseData = new MouseData { hasValue = false };
        private Vector2 _lastMousePosition = Vector2.zero;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            Vector2 mousePosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(0)) 
            {
                MouseDown(mousePosition);
            }
            else if (Input.GetMouseButton(0)) 
            {
                MouseDrag(mousePosition);
            }
            else if (Input.GetMouseButtonUp(0)) 
            {
                MouseUp(mousePosition);
            }
        }

        private void MouseDown(Vector2 position)
        {
            _lastMousePosition = position;

            var data = new MouseData
            {
                hasValue = true,
                position = position,
                deltaPosition = Vector2.zero
            };

            _currentMouseData = data;
            OnMouseDown?.Invoke(data);
        }

        private void MouseDrag(Vector2 position)
        {
            var data = new MouseData
            {
                hasValue = true,
                position = position,
                deltaPosition = position - _lastMousePosition
            };

            _lastMousePosition = position;
            _currentMouseData = data;
            OnMouseDrag?.Invoke(data);
        }

        private void MouseUp(Vector2 position)
        {
            var data = new MouseData
            {
                hasValue = false,
                position = position,
                deltaPosition = position - _lastMousePosition
            };

            _currentMouseData = data;
            OnMouseUp?.Invoke(data);
        }
    }
}

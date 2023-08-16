using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DesignPatterns.Observer
{
    [RequireComponent(typeof(Collider))]
    public class ButtonSubject: MonoBehaviour
    {
        public static event Action Clicked;

        private Collider _collider;

        void Start()
        {
            _collider = GetComponent<Collider>();
        }

        void Update()
        {
            CheckCollider();
        }

        private void CheckCollider()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
                {
                    if (hitInfo.collider == _collider)
                    {
                        ClickButton();
                    }
                }
            }
        }

        private void ClickButton()
        {
            Clicked?.Invoke();
        }
    }
}


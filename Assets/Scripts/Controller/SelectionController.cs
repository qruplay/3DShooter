using System;
using Interface;
using UnityEngine;

namespace Controller
{
    public class SelectionController : BaseController, IUpdate
    {
        private readonly Camera _mainCamera;
        private readonly Vector2 _screenCenter;
        private readonly float _selectionDistance = 20;
        private GameObject _hitGameObject;
        private ISelectable _selectedGameObject;
        private bool _isObjectSelected;

        public SelectionController()
        {
            _mainCamera = Camera.main;
            _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        public void OnUpdate()
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(_screenCenter), out RaycastHit hit, _selectionDistance))
            {
                SelectObject(hit.collider.gameObject);
            } else if(_isObjectSelected) 
            {
                _hitGameObject = null;
                _isObjectSelected = false;
                UiInterface.SelectionUi.Text = String.Empty;
            }
        }

        public void SelectObject(GameObject hitObject)
        {
            if (hitObject == _hitGameObject) return;

            _selectedGameObject = hitObject.GetComponent<ISelectable>();
            if (_selectedGameObject != null)
            {
                UiInterface.SelectionUi.Text = _selectedGameObject.GetMessage();
                _isObjectSelected = true;
            } else
            {
                UiInterface.SelectionUi.Text = String.Empty;
                _isObjectSelected = false;
            }

            _hitGameObject = hitObject;
        }
    }
}
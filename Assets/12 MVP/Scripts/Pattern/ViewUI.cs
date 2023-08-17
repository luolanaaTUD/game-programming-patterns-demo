using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace DesignPatterns.MVP
{
    public class ViewUI : MonoBehaviour, IView
    {

        [Header("Presenter")]
        [SerializeField] HealthPresenter _presenter;

        public IPresenter Presenter => _presenter;


        private Slider _healthSlider;

        private IntegerField _healthValue;

        private Button _resetButton;

        private void Awake()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            _healthSlider = root.Q<Slider>("health_slider");
            _healthValue = root.Q<IntegerField>("health_value");
            _resetButton = root.Q<Button>("reset_button");
        }


        void Start()
        {
            _resetButton.clicked += () => _presenter.Reset();

            _healthSlider.RegisterValueChangedCallback(evt =>
            {
                _healthValue.value = (int)evt.newValue;
            });
        }


        private void OnDestroy()
        {
            _resetButton.clicked -= () => _presenter.Reset();
        }


        public void UpdateHealthValue(float value)
        {
            _healthSlider.value = value;
        }
    }
}

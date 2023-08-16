using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.MVP
{
    // The Presenter. This listens for View changes in the user interface and the manipulates the Model (Health) in response.
    // The Presenter updates the View when the Model changes.

    public class HealthPresenter : MonoBehaviour, IPresenter
    {
        [Header("Model")]
        [SerializeField] Health _health;

        [Header("View")]
        [SerializeField] Slider healthSlider;
        [SerializeField] Text healthText;

        [Header("Audio")]
        [SerializeField] AudioClip[] _clips;



        /// <summary>
        /// Other observer components need to attach to this presenter.
        /// </summary>
        //private AudioSource _audioSource;



        public IModel Model => _health;

        public IView View => throw new System.NotImplementedException();


        //private void Awake()
        //{
        //    _audioSource = this.GetComponent<AudioSource>();
        //}

        private void Start()
        {
            if (_health != null)
            {
                _health.HealthChanged += OnHealthChanged;
                _health.ZeroHealth += OnHealthToZero;
            }
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.HealthChanged -= OnHealthChanged;
                _health.ZeroHealth -= OnHealthToZero;
            }
        }

        //private void OnEnable()
        //{
        //    Health.HealthChanged += OnHealthChanged;
        //    Reset();
        //}

        //private void OnDisable()
        //{
        //    Health.HealthChanged -= OnHealthChanged;
        //}


        #region To Model

        // send damage to the model
        public void Damage(int amount)
        {
            if(_health != null)
                _health.Decrement(amount);
        }

        public void Heal(int amount)
        {
            if (_health != null)
                _health.Increment(amount);
        }

        // send reset to the model
        public void Reset()
        {
            if (_health != null)
                _health.Restore();
        }


        public int GetCurrentHealth()
        {
            if (_health == null)
                return -1;

            return _health.CurrentHealth;
        }

        #endregion

        #region To View

        private void UpdateView()
        {
            if (_health == null)
                return;

            // format the data for view
            if (healthSlider !=null && _health.MaxHealth != 0)
            {
                healthSlider.value = (float)_health.CurrentHealth / (float)_health.MaxHealth;
            }

            if (healthText != null)
            {
                healthText.text = $"{_health.CurrentHealth}";
            }
        }

        // listen for model changes and update the view
        public void OnHealthChanged()
        {
            UpdateView();
            AudioManager.Instance.PlaySoundEffect(_clips[0]);
        }

        public void OnHealthToZero()
        {
            //_audioSource.Play();
            AudioManager.Instance.PlaySoundEffect(_clips[1]);
        }
        #endregion
    }
}

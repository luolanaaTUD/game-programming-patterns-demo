using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace DesignPatterns.MVP
{
    // The Model. This contains the data for our MVP pattern.
    public class Health : MonoBehaviour, IModel
    {
        // This event notifies the Presenter that the health has changed.
        // This is useful if setting the value (e.g. saving to disk or
        // storing in a database) takes some time.

        // For MVP, doesn't use static event will increase the usage of model.
        public event Action HealthChanged;
        public event Action ZeroHealth;


        public event Action<int> Amount;

        private const int minHealth = 0;
        private const int maxHealth = 100;
        private int _currentHealth = maxHealth;

        public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
        public int MinHealth => minHealth;
        public int MaxHealth => maxHealth;

        public string ModelName { get => nameof(Health); set => ModelName = value;}

        public void Increment(int amount)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, minHealth, maxHealth);
            UpdateHealth();
        }

        public void Decrement(int amount)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, minHealth, maxHealth);
            UpdateHealth();

            if (_currentHealth <= 0)
                ZeroHealth?.Invoke();
        }

        // max the health value
        public void Restore()
        {
            _currentHealth = maxHealth;
            UpdateHealth();
        }

        // invokes the event
        public void UpdateHealth()
        {
            HealthChanged?.Invoke();
        }
    }
}

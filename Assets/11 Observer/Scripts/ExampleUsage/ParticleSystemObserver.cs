using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer
{

    public class ParticleSystemObserver : MonoBehaviour
    {
        //[SerializeField] ButtonSubject subjectToObserve;
        [SerializeField] private ParticleSystem _particleSystem;

        //private void Awake()
        //{
        //    if (subjectToObserve != null)
        //    {
        //        subjectToObserve.Clicked += OnThingHappened;
        //    }

        //}

        private void OnEnable()
        {
            ButtonSubject.Clicked += OnThingHappened;
        }

        private void OnDisable()
        {
            ButtonSubject.Clicked -= OnThingHappened;
        }

        private void OnThingHappened()
        {
            if (_particleSystem != null)
            {
                _particleSystem.Stop();
                _particleSystem.Play();
            }
        }

        //private void OnDestroy()
        //{
        //    //unsubscribe / deregister from the event if we destroy the object
        //    if (subjectToObserve != null)
        //    {
        //        subjectToObserve.Clicked -= OnThingHappened;
        //    }

        //}

    }
}

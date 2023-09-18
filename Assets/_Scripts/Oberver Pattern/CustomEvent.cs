using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public class CustomEvent
    {
        event Action _action;

        public void Invoke()
        {
            _action?.Invoke();
        }

        public void AddListener(Action listener) => _action += listener;

        public void RemoveListener(Action listener) => _action -= listener;
    }
    public class CustomEvent<T>
    {
        event Action<T> _action;

        public void Invoke(T pram)
        {
            _action?.Invoke(pram);
        }

        public void AddListener(Action<T> listener) => _action += listener;

        public void RemoveListener(Action<T> listener) => _action -= listener;
    }

    public class CustomEvent<T1, T2>
    {
        event Action<T1, T2> _action;

        public void Invoke(T1 param1, T2 param2)
        {
            _action?.Invoke(param1, param2);
        }

        public void AddListener(Action<T1, T2> listener) => _action += listener;

        public void RemoveListener(Action<T1, T2> listener) => _action -= listener;
    }

}


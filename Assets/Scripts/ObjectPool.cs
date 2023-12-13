﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _poolSize;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject instance;
            if (_container != null)
                instance = Instantiate(_template, _container);
            else
                instance = Instantiate(_template, transform.position, _template.transform.rotation);
            _pool.Add(instance);
            instance.SetActive(false);
        }
    }

    protected bool TryGetElement(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
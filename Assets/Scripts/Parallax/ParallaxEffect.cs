using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _parallaxSpeed;
    
    private Camera _mainCamera;
    private float _lengthOfSprite;
    private float _startPosition;
    
    private Transform[] _backgrounds;
    
    private void Start()
    {
        _mainCamera = ServiceLocator.MainCamera;
        _startPosition = transform.position.x;
        InitializeSprites();
    }

    private void InitializeSprites()
    {
        _backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _backgrounds[i] = transform.GetChild(i);
        }

        _lengthOfSprite = _backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void FixedUpdate()
    {
        TryRepeat();
        MoveBackground();
    }

    private void TryRepeat()
    {
        if (_mainCamera.transform.position.x > _backgrounds[0].position.x + _lengthOfSprite)
        {
            _backgrounds[0].transform.position += Vector3.right * _lengthOfSprite * 2;
            
            (_backgrounds[0], _backgrounds[1]) = (_backgrounds[1], _backgrounds[0]);
        }
    }

    private void MoveBackground()
    {
        float distance = _mainCamera.transform.position.x * _parallaxSpeed;

        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);
    }
}

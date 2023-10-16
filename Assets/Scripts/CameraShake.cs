using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrength,_rotationStrenght;

    private static event Action Shake;
    public static void Invoke()
    {
        Shake?.Invoke();
    }
    private void OnEnable() => Shake += CamShake;
    private void OnDisable() => Shake -= CamShake;

    private void CamShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, _positionStrength);
        _camera.DOShakeRotation(0.3f,_rotationStrenght);
    }
}

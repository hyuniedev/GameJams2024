using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetSizeCinemaChine : MonoBehaviour
{
    private CinemachineVirtualCamera _camChine;
    [SerializeField] private CinemachineTargetGroup ccTarget;
    private float _buffer = 3f;
    private void Awake()
    {
        _camChine = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        var (center, size) = CalculaterOrthoSize();
        _camChine.m_Lens.OrthographicSize = size;
        _camChine.transform.position = center;
    }

    private (Vector3 center, float size) CalculaterOrthoSize()
    {
        var bounds = new Bounds();
        for (int i = 0; i < ccTarget.m_Targets.Length; i++)
        {
            bounds.Encapsulate(ccTarget.m_Targets[i].target.position);
        }
        bounds.Expand(_buffer);

        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * 6 / 9;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0, 0, -10);
        return (center, size);
    }
}

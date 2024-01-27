using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MutiplayerFollowCamera : MonoBehaviour
{
     public List<Transform> targets;
     private float _buffer = 3f;
     private Camera _cam;

     private void Awake()
     {
          _cam = GetComponent<Camera>();
     }

     private void Update()
     {
          var (center, size) = CalculaterOrthoSize();
          _cam.transform.position = center;
          _cam.orthographicSize = size;
     }

     private (Vector3 center, float size) CalculaterOrthoSize()
     {
          var bounds = new Bounds();
          for (int i = 0; i < targets.Count; i++)
          {
               bounds.Encapsulate(targets[i].position);
          }
          bounds.Expand(_buffer);

          var vertical = bounds.size.y;
          var horizontal = bounds.size.x * _cam.pixelHeight / _cam.pixelWidth;

          var size = Mathf.Max(horizontal, vertical) * 0.5f;
          var center = bounds.center + new Vector3(0, 0, -10);
          return (center, size);
     }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip("Game Units per second")]
    [SerializeField] private float scrollRate = 0.2f;
    private void Update()
    {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
}

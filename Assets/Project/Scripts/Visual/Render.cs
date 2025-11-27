using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{
    protected Animator _animator;
    protected void InitRender()
    {
        _animator = GetComponent<Animator>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryTest : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

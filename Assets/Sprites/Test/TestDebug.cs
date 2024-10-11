using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebug : MonoBehaviour
{
    InputFieldClass test_02_Sinby;

    private void Awake()
    {
        test_02_Sinby = FindAnyObjectByType<InputFieldClass>();
        //test_02_Sinby.TotalText += AAA;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    private void AAA(string obj)
    {
        Debug.Log($" 전송된 텍스트 : {obj}");
    }
}

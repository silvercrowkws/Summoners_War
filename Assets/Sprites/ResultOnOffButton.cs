using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultOnOffButton : MonoBehaviour
{
    /// <summary>
    /// 소환 결과창
    /// </summary>
    SummonResult summonResult;

    /// <summary>
    /// 소환 결과창 온오프 버튼
    /// </summary>
    Button onoffButton;

    private void Awake()
    {
        onoffButton = GetComponent<Button>();
        onoffButton.onClick.AddListener(ResultActiveOnOff);
    }

    private void Start()
    {
        summonResult = FindAnyObjectByType<SummonResult>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void ResultActiveOnOff()
    {
        // 만약 결과창이 활성화 되어 있으면
        if (summonResult.gameObject.activeSelf)
        {       
            // 결과창 끄기
            summonResult.gameObject.SetActive(false);
        }
        // 만약 결과창이 활성화 되어있지 않으면
        else if(!summonResult.gameObject.activeSelf)
        {
            // 결과창 켜기
            summonResult.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("결과창 온오프 오류");
        }
    }
}

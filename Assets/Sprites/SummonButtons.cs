using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButtons : MonoBehaviour
{
    /// <summary>
    /// 버튼의 배열
    /// </summary>
    public Button[] buttons;

    /// <summary>
    /// 버튼을 눌렀으니 인풋필드의 스프라이트를 바꾸라고 알리는 델리게이트
    /// </summary>
    public Action<int> onChangeSprite;

    private void Awake()
    {
        // 버튼 배열이 비어 있지 않은 경우에만 처리
        if (buttons.Length > 0)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                int index = i; // 클로저 문제 방지
                buttons[i].onClick.AddListener(() => AAA(index)); // 클릭 이벤트에 인덱스 전달
            }
        }
        else
        {
            Debug.LogWarning("버튼 배열이 비어 있다.");
        }
    }

    /// <summary>
    /// 버튼 클릭 시 호출되는 메서드
    /// </summary>
    /// <param name="index">눌린 버튼의 인덱스</param>
    private void AAA(int index)
    {
        // 디버그로 어떤 버튼이 눌렸는지 표시
        onChangeSprite?.Invoke(index);
        Debug.Log($"{index + 1} 버튼 클릭");
    }
}

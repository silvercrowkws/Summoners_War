using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldClass : MonoBehaviour
{
    /// <summary>
    /// 인풋 필드
    /// </summary>
    TMP_InputField inputField;

    /// <summary>
    /// totalText을 델리게이트로 터미널에 보내기 위한 델리게이트
    /// </summary>
    public Action<int> TotalText;

    /// <summary>
    /// 소환서 스프라이트의 배열
    /// </summary>
    public Sprite[] sprites;

    /// <summary>
    /// 소환서 버튼
    /// </summary>
    SummonButtons summonButtons;

    /// <summary>
    /// 옆에 있는 소환서 이미지
    /// </summary>
    Image image;

    private void Awake()
    {
        Transform child = transform.GetChild(1);
        image = child.GetComponent<Image>();        // 1번째 자식의 이미지

        inputField = GetComponent<TMP_InputField>();
        inputField.onSubmit.AddListener((text) =>
        {
            //TotalText?.Invoke(text);
            if (int.TryParse(text, out int summonCount)) // 문자열을 int로 변환
            {
                TotalText?.Invoke(summonCount); // 변환된 정수를 델리게이트에 전달
            }
            else
            {
                Debug.LogWarning("Invalid input. Please enter a valid number.");
            }
            ClearText();
            /*if (terminal.TerminalUse)
                inputField.ActivateInputField();        //InputField를 활성화하는 함수*/
        });
    }

    private void Start()
    {
        summonButtons = FindAnyObjectByType<SummonButtons>();
        summonButtons.onChangeSprite += OnChangeSprite;
    }

    /// <summary>
    /// 버튼에 해당하는 소환서 이미지로 바꾸는 함수
    /// </summary>
    /// <param name="index"></param>
    private void OnChangeSprite(int index)
    {
        image.sprite = sprites[index];
    }

    /// <summary>
    /// 문자열을 비우기 위한 함수
    /// </summary>
    public void ClearText()
    {
        inputField.text = string.Empty;
    }
}

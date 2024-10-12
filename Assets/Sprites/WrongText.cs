using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WrongText : MonoBehaviour
{
    /// <summary>
    /// 이 클래스의 이미지
    /// </summary>
    Image image;

    /// <summary>
    /// 이 클래스의 자식 텍스트 매쉬 프로
    /// </summary>
    TextMeshProUGUI textMeshProUGUI;

    /// <summary>
    /// 알파값이 줄어드는 시간
    /// </summary>
    float fadeDuration = 2.0f;

    private void Awake()
    {
        image = GetComponent<Image>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        //this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        this.gameObject.SetActive(true);        // 이 게임 오브젝트 활성화

        // 알파값을 1로 초기화
        Color imageColor = image.color;
        Color textColor = textMeshProUGUI.color;

        imageColor.a = 1.0f;
        textColor.a = 1.0f;

        image.color = imageColor;
        textMeshProUGUI.color = textColor;

        StartCoroutine(FadeOutCoroutine());     // 활성화 시 코루틴 시작
    }

    IEnumerator FadeOutCoroutine()
    {
        float startAlpha = 1.0f; // 시작 알파 값
        float time = 0;

        // 이미지와 텍스트의 색상 설정
        Color imageColor = image.color;
        Color textColor = textMeshProUGUI.color;

        yield return new WaitForSeconds(fadeDuration);      // fadeDuration동안 기다리고

        while (time < fadeDuration)
        {
            // 경과 시간을 기반으로 알파 값 계산
            float alpha = Mathf.Lerp(startAlpha, 0, time / fadeDuration);
            imageColor.a = alpha;
            textColor.a = alpha;

            // 색상 적용
            image.color = imageColor;
            textMeshProUGUI.color = textColor;

            time += Time.deltaTime; // 경과 시간 업데이트
            yield return null; // 다음 프레임까지 대기            
        }

        // 최종적으로 알파 값을 0으로 설정
        imageColor.a = 0;
        textColor.a = 0;
        image.color = imageColor;
        textMeshProUGUI.color = textColor;

        // 이미지 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }

}

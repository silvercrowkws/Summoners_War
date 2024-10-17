using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonResult : MonoBehaviour
{
    /// <summary>
    /// 물불풍 4성 몬스터
    /// </summary>
    public Sprite[] wfw_Monster_4;

    /// <summary>
    /// 물불풍 5성 몬스터
    /// </summary>
    public Sprite[] wfw_Monster_5;

    // 빛암속성 몬스터 ----------------------------------------

    /// <summary>
    /// 빛암 4성 몬스터
    /// </summary>
    public Sprite[] ld_Monster_4;

    /// <summary>
    /// 빛암 5성 몬스터
    /// </summary>
    public Sprite[] ld_Monster_5;

    // 물속성 몬스터 ----------------------------------------

    /// <summary>
    /// 물 4성 몬스터
    /// </summary>
    public Sprite[] water_Monster_4;

    /// <summary>
    /// 물 5성 몬스터
    /// </summary>
    public Sprite[] water_Monster_5;

    // 불속성 몬스터 ----------------------------------------

    /// <summary>
    /// 불 4성 몬스터
    /// </summary>
    public Sprite[] fire_Monster_4;

    /// <summary>
    /// 불 5성 몬스터
    /// </summary>
    public Sprite[] fire_Monster_5;

    // 픙속성 몬스터 ----------------------------------------

    /// <summary>
    /// 풍 4성 몬스터
    /// </summary>
    public Sprite[] wind_Monster_4;

    /// <summary>
    /// 풍 5성 몬스터
    /// </summary>
    public Sprite[] wind_Monster_5;

    // 기타 ----------------------------------------

    /// <summary>
    /// 소환서 선택 버튼
    /// </summary>
    SummonButtons summonButtons;

    /// <summary>
    /// 인풋 필드 클래스
    /// </summary>
    InputFieldClass inputFieldClass;

    /// <summary>
    /// 소환서 번호
    /// 1: 신비, 2: 물, 3: 불, 4: 풍, 5: 빛암
    /// 6: 전설, 7: 물전설, 8: 불전설, 9: 풍전설, 10: 전전소
    /// 기본은 신비
    /// </summary>
    int summonNumber = 1;

    /// <summary>
    /// content의 자식으로 있는 이미지들의 배열
    /// </summary>
    Image[] images;

    /// <summary>
    /// 현재 이미지의 인덱스
    /// </summary>
    private int currentIndex = 0;

    /// <summary>
    /// 개수가 초과 되었을 때 보여질 텍스트(이미지)
    /// </summary>
    WrongText wrongText;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        child = child.GetChild(0);
        images = child.GetComponentsInChildren<Image>();
    }

    private void Start()
    {
        summonButtons = FindAnyObjectByType<SummonButtons>();
        inputFieldClass = FindAnyObjectByType<InputFieldClass>();
        wrongText = FindObjectOfType<WrongText>(true);      // 비활성화 된 상태이기 때문에 이렇게 찾음

        // 람다식으로 값 변경
        summonButtons.onChangeSprite += (index) =>
        {
            summonNumber = index + 1;
            Debug.Log(summonNumber);
        };

        inputFieldClass.TotalText += SummonFC;

        ClearImage();
    }

    /// <summary>
    /// 몬스터를 소환하는 함수
    /// </summary>
    /// <param name="summonCount">몬스터를 소환하는 횟수</param>
    private void SummonFC(int summonCount)
    {
        ClearImage();

        switch (summonNumber)
        {
            // 신비 소환서 ----------------------------------------------------------------------------------------------------
            case 1:     // 신비 소환서(물불풍 소환)

                // 소환서 개수 999 까지만 허용
                if (summonCount < 1000)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        //int randomValue = UnityEngine.Random.Range(0, 100); // 0부터 100 사이의 랜덤 값 생성
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.5% 확률로 wfw_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.005f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 8% 확률로 wfw_Monster_4 에서 몬스터 소환
                        else if (randomValue >= 0.005f && randomValue < 0.085f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("3성 소환");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 물 소환서 ----------------------------------------------------------------------------------------------------
            case 2:     // 물 소환서

                // 소환서 개수 999 까지만 허용
                if (summonCount < 1000)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.5% 확률로 water_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.005f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, water_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = water_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 8% 확률로 water_Monster_4 에서 몬스터 소환
                        else if (randomValue >= 0.005f && randomValue < 0.085f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, water_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = water_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("3성 소환");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 불 소환서 ----------------------------------------------------------------------------------------------------
            case 3:     // 불 소환서

                // 소환서 개수 999 까지만 허용
                if (summonCount < 1000)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.5% 확률로 fire_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.005f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, fire_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = fire_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 8% 확률로 fire_Monster_4 에서 몬스터 소환
                        else if (randomValue >= 0.005f && randomValue < 0.085f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, fire_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = fire_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("3성 소환");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 풍 소환서 ----------------------------------------------------------------------------------------------------
            case 4:     // 풍 소환서

                // 소환서 개수 999 까지만 허용
                if (summonCount < 1000)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.5% 확률로 wind_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.005f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wind_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wind_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 8% 확률로 wind_Monster_4 에서 몬스터 소환
                        else if (randomValue >= 0.005f && randomValue < 0.085f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wind_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wind_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("3성 소환");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 빛암 소환서 ----------------------------------------------------------------------------------------------------
            case 5:     // 빛암 소환서

                // 소환서 개수 999 까지만 허용
                if (summonCount < 1000)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.35% 확률로 ld_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.0035f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, ld_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = ld_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 6% 확률로 ld_Monster_4 에서 몬스터 소환
                        else if (randomValue >= 0.0035f && randomValue < 0.0635f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, ld_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = ld_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("3성 소환");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 전설 소환서 ----------------------------------------------------------------------------------------------------
            case 6:     // 전설 소환서

                // 소환서 개수가 100까지만 허용
                if(summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        Debug.Log($"{i + 1} 번 반복");
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 6.5% 확률로 wfw_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.065f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 93.5% 확률로 wfw_Monster_4 에서 몬스터 소환
                        else // (randomValue < 0.935f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 물전설 소환서 ----------------------------------------------------------------------------------------------------
            case 7:     // 물전설 소환서

                // 소환서 개수가 100까지만 허용
                if (summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 6.5% 확률로 water_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.065f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, water_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = water_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 93.5% 확률로 water_Monster_4 에서 몬스터 소환
                        else //(randomValue < 0.935f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, water_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = water_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 불전설 소환서 ----------------------------------------------------------------------------------------------------
            case 8:     // 불전설 소환서

                // 소환서 개수가 100까지만 허용
                if (summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 6.5% 확률로 fire_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.065f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, fire_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = fire_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 93.5% 확률로 fire_Monster_4 에서 몬스터 소환
                        else //(randomValue < 0.935f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, fire_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = fire_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 풍전설 소환서 ----------------------------------------------------------------------------------------------------
            case 9:     // 풍전설 소환서

                // 소환서 개수가 100까지만 허용
                if (summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 6.5% 확률로 wind_Monster_5 에서 몬스터 소환
                        if (randomValue < 0.065f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wind_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wind_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 93.5% 확률로 wind_Monster_4 에서 몬스터 소환
                        else //(randomValue < 0.935f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wind_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wind_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 전속성 전설 소환서 ----------------------------------------------------------------------------------------------------
            case 10:     // 전속성 전설 소환서

                // 소환서 개수가 100까지만 허용
                if (summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        float randomValue = UnityEngine.Random.Range(0f, 1f); // 0과 1 사이의 랜덤 숫자 생성

                        // 0.4% 확률로 ld_Monster_5 에서 몬스터 소환(빛암 5성)
                        if (randomValue < 0.004f)
                        {
                            int randomIndex = UnityEngine.Random.Range(0, ld_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = ld_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 6.7% 확률로 wfw_Monster_5 에서 몬스터 소환(물불풍 5성)
                        else if (randomValue  >= 0.004 && randomValue < 0.071f)     // 0.071 - 0.004 = 0.067
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_5.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_5[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 7.5% 확률로 ld_Monster_4 에서 몬스터 소환(빛암 4성)
                        else if (randomValue >= 0.071 && randomValue < 0.146f)      // 0.146-0.071 = 0.075
                        {
                            int randomIndex = UnityEngine.Random.Range(0, ld_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = ld_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        // 85.4% 확률로 wfw_Monster_4 에서 몬스터 소환(물불풍 4성)
                        else if(randomValue >= 0.146f)      // 1- 0.146 = 0.854
                        {
                            int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_4.Length); // 랜덤 인덱스 선택
                            Sprite summonedMonster = wfw_Monster_4[randomIndex];                 // 몬스터 소환
                            Debug.Log($"소환된 4성 몬스터: {summonedMonster.name}");

                            // images 배열에 소환된 몬스터 이미지 할당
                            images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                            images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                            currentIndex++; // 인덱스 증가
                        }
                        else
                        {
                            //Debug.Log("버그");
                        }
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;

            // 초월 소환서 ----------------------------------------------------------------------------------------------------
            case 11:     // 초월 소환서

                // 소환서 개수가 100까지만 허용
                if (summonCount < 101)
                {
                    for (int i = 0; i < summonCount; i++)
                    {
                        // 100% 확률로 wfw_Monster_5 에서 몬스터 소환(물불풍 5성)
                        int randomIndex = UnityEngine.Random.Range(0, wfw_Monster_5.Length); // 랜덤 인덱스 선택
                        Sprite summonedMonster = wfw_Monster_5[randomIndex];                 // 몬스터 소환
                        Debug.Log($"소환된 5성 몬스터: {summonedMonster.name}");

                        // images 배열에 소환된 몬스터 이미지 할당
                        images[currentIndex].color = Color.white;       // 알파값을 1로 설정하여 보이게 함
                        images[currentIndex].sprite = summonedMonster;  // 이미지 업데이트
                        currentIndex++; // 인덱스 증가
                    }
                }
                else
                {
                    Debug.Log($"최대 수량 초과");
                    WrongTextActive();
                }
                break;
        }

    }

    /// <summary>
    /// images 배열을 초기화 하는 함수
    /// </summary>
    private void ClearImage()
    {
        // images 배열의 모든 스프라이트를 null로 초기화
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = null; // 이미지 초기화

            images[i].color = Color.clear; // 알파값 0으로 설정
        }

        this.gameObject.SetActive(true);        // 이 게임 오브젝트 활성화

        // currentIndex를 0으로 재설정
        currentIndex = 0;
    }

    /// <summary>
    /// WrongText를 활성화 하는 함수
    /// </summary>
    private void WrongTextActive()
    {
        wrongText.gameObject.SetActive(true);
    }
}

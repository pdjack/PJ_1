using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GradeWeights
{
    public float common;
    public float rare;
    public float epic;
    public float legendary;

    public float TotalWeight => common + rare + epic + legendary;

    public CardGrade Roll()
    {
        float randomValue = Random.Range(0, TotalWeight);

        if ((randomValue -= common) < 0) return CardGrade.Common;
        if ((randomValue -= rare) < 0) return CardGrade.Rare;
        if ((randomValue -= epic) < 0) return CardGrade.Epic;

        return CardGrade.Legendary;
    }

    public GradeWeights(float common, float rare, float epic, float legendary)
    {
        this.common = common;
        this.rare = rare;
        this.epic = epic;
        this.legendary = legendary;
    }
}

[CreateAssetMenu(fileName = "CardManager", menuName = "ScriptableObjects/UpgradeCard/CardManager")]
public class CardManager : ScriptableObject
{
    [Header("All Upgrade Cards")]
    [SerializeField] private List<UpgradeCardData> allCards = new List<UpgradeCardData>();

    [Header("Grade Probabilities (Total should be 100)")]
    [SerializeField] private GradeWeights probabilities = new GradeWeights(70, 20, 8, 2);

    public List<UpgradeCardData> GetRandomCards(int count)
    {
        List<UpgradeCardData> result = new List<UpgradeCardData>();
        List<UpgradeCardData> tempAllCards = new List<UpgradeCardData>(allCards);
        
        // 추가: Inspector에서 할당되지 않았거나 스크립트가 변경되어 누락된(null) 카드 데이터를 방어합니다.
        tempAllCards.RemoveAll(card => card == null);

        for (int i = 0; i < count; i++)
        {
            if (tempAllCards.Count == 0) break;

            CardGrade selectedGrade = GetRandomGrade();
            UpgradeCardData pickedCard = PickCardByGrade(selectedGrade, tempAllCards);

            if (pickedCard != null)
            {
                result.Add(pickedCard);
                tempAllCards.Remove(pickedCard);
            }
        }

        return result;
    }

    private CardGrade GetRandomGrade()
    {
        return probabilities.Roll();
    }

    private UpgradeCardData PickCardByGrade(CardGrade grade, List<UpgradeCardData> pool)
    {
        // 1. 해당 등급의 카드들만 필터링
        List<UpgradeCardData> matchingCards = pool.FindAll(card => card.grade == grade);

        // 2. 해당 등급의 카드가 있다면 무작위 선택
        if (matchingCards.Count > 0)
        {
            return matchingCards[Random.Range(0, matchingCards.Count)];
        }

        // 3. 보완 로직: 해당 등급의 자원이 없으면 전체 풀에서 무작위 선택
        return pool[Random.Range(0, pool.Count)];
    }
    
    public void PickAndShow()
    {
        List<UpgradeCardData> pickedCards = GetRandomCards(2);
        
        // 카드가 1장이라도 뽑혔을 때만 올바르게 패널을 띄웁니다. 카드를 하나도 못뽑은 채로 UI를 띄우면 빈 창만 나오고 시간이 멈춥니다.
        if (pickedCards != null && pickedCards.Count > 0)
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowUpgradePanel(pickedCards);
            }
        }
        else
        {
            Debug.LogWarning("CardManager: 뽑을 수 있는 유효한 카드(UpgradeCardData)가 하나도 설정되어 있지 않아 업그레이드 패널을 띄우지 못했습니다.");
        }
    }
}

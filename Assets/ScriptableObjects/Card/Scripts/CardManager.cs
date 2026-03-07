using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardManager", menuName = "ScriptableObjects/UpgradeCard/CardManager")]
public class CardManager : ScriptableObject
{
    [Header("All Upgrade Cards")]
    public List<UpgradeCardData> allCards = new List<UpgradeCardData>();

    /// <summary>
    /// 무작위로 n개의 중복되지 않는 카드를 선택하여 반환합니다.
    /// </summary>
    public List<UpgradeCardData> GetRandomCards(int count)
    {
        List<UpgradeCardData> result = new List<UpgradeCardData>();
        List<UpgradeCardData> tempPool = new List<UpgradeCardData>(allCards);

        for (int i = 0; i < count; i++)
        {
            if (tempPool.Count == 0) break;

            int randomIndex = Random.Range(0, tempPool.Count);
            result.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex);
        }

        return result;
    }
}

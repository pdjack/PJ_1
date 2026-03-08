using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GradeWeights
{
    public float common;
    public float rare;
    public float epic;
    public float legendary;

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
    public List<UpgradeCardData> allCards = new List<UpgradeCardData>();

    [Header("Grade Probabilities (Total should be 100)")]
    public GradeWeights probabilities = new GradeWeights(70, 20, 8, 2);

    public List<UpgradeCardData> GetRandomCards(int count)
    {
        List<UpgradeCardData> result = new List<UpgradeCardData>();
        List<UpgradeCardData> tempPool = new List<UpgradeCardData>(allCards);

        for (int i = 0; i < tempPool.Count; i++)
        {
            int randomIndex = Random.Range(0, tempPool.Count);
            result.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex);
        }

        return result;
    }
    
    public void PickAndShow()
    {
        List<UpgradeCardData> pickedCards = GetRandomCards(2);
        
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowUpgradePanel(pickedCards);
        }
    }
}

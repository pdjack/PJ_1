using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// 업그레이드 카드 에셋을 생성하고 CardManager에 자동 등록하는 툴입니다.
/// </summary>
public static class CardCreatorUtility
{
    private const string CardsFolder = "Assets/ScriptableObjects/Card/Assets/";
    private const string CardManagerPath = "Assets/ScriptableObjects/Card/CardManager.asset";

    [MenuItem("PJ1/Utility/Create Default Stat Card")]
    public static void CreateDefaultCard()
    {
        // 1. 새 카드 데이터 인스턴스 생성
        StatUpgradeCardData newCard = ScriptableObject.CreateInstance<StatUpgradeCardData>();
        newCard.cardName = "New Stat Upgrade";
        newCard.description = "Modify stat by value.";
        newCard.grade = CardGrade.Common;

        // 2. 폴더 확인 및 저장
        if (!Directory.Exists(CardsFolder)) Directory.CreateDirectory(CardsFolder);
        string uniquePath = AssetDatabase.GenerateUniqueAssetPath(CardsFolder + "NewStatCard.asset");
        AssetDatabase.CreateAsset(newCard, uniquePath);

        // 3. CardManager에 등록
        CardManager manager = AssetDatabase.LoadAssetAtPath<CardManager>(CardManagerPath);
        if (manager != null)
        {
            // Reflection이나 SerializedObject를 사용하여 private 리스트에 접근하거나,
            // public인 경우 직접 추가합니다.
            SerializedObject so = new SerializedObject(manager);
            SerializedProperty allCardsProp = so.FindProperty("allCards");
            allCardsProp.InsertArrayElementAtIndex(allCardsProp.arraySize);
            allCardsProp.GetArrayElementAtIndex(allCardsProp.arraySize - 1).objectReferenceValue = newCard;
            so.ApplyModifiedProperties();
            
            Debug.Log($"PJ1: Created and Registered Card at {uniquePath}");
        }
        else
        {
            Debug.LogError($"PJ1: Could not find CardManager at {CardManagerPath}");
        }

        AssetDatabase.SaveAssets();
    }
}

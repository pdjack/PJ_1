using UnityEngine;
using UnityEditor;
using System.IO;

public static class PJ1_AutomationTools
{
    private const string CardsFolder = "Assets/ScriptableObjects/Card/Assets/";
    private const string CardManagerPath = "Assets/ScriptableObjects/Card/CardManager.asset";

    [MenuItem("PJ1/Automation/Register New Card Template")]
    public static void CreateDefaultCard()
    {
        StatUpgradeCardData newCard = ScriptableObject.CreateInstance<StatUpgradeCardData>();
        newCard.cardName = "NEW_CARD_TEMPLATE";
        newCard.description = "Modify stat by value.";
        newCard.grade = CardGrade.Common;

        if (!Directory.Exists(CardsFolder)) Directory.CreateDirectory(CardsFolder);
        string uniquePath = AssetDatabase.GenerateUniqueAssetPath(CardsFolder + "NewStatCard.asset");
        AssetDatabase.CreateAsset(newCard, uniquePath);

        CardManager manager = AssetDatabase.LoadAssetAtPath<CardManager>(CardManagerPath);
        if (manager != null)
        {
            SerializedObject so = new SerializedObject(manager);
            SerializedProperty allCardsProp = so.FindProperty("allCards");
            allCardsProp.InsertArrayElementAtIndex(allCardsProp.arraySize);
            allCardsProp.GetArrayElementAtIndex(allCardsProp.arraySize - 1).objectReferenceValue = newCard;
            so.ApplyModifiedProperties();
            
            Debug.Log($"PJ1: Created and Registered Card at {uniquePath}");
        }
        AssetDatabase.SaveAssets();
    }

    [MenuItem("PJ1/Automation/Setup Scene All")]
    public static void SetupStandardScene()
    {
        EnsureManager<WaveManager>("WaveManager");
        EnsureManager<UIManager>("UIManager");
        EnsureManager<UpgradeManager>("UpgradeManager");
        EnsureManager<MonsterSpawn>("MonsterSpawn");
        Debug.Log("PJ1: Scene Setup Success.");
    }

    private static T EnsureManager<T>(string n) where T : MonoBehaviour
    {
        T manager = Object.FindAnyObjectByType<T>();
        if (manager == null) {
            var go = new GameObject(n);
            manager = go.AddComponent<T>();
            Debug.Log($"PJ1: Created {n}");
        }
        return manager;
    }
}

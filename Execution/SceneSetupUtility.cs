using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// PJ_1 프로젝트의 씬 구성을 자동화하는 에디터 유틸리티입니다.
/// 모든 필수 매니저와 기본 UI 구조를 확인하고 생성합니다.
/// </summary>
public static class SceneSetupUtility
{
    [MenuItem("PJ1/Scene/Setup Standard Scene")]
    public static void SetupStandardScene()
    {
        // 1. 필수 매니저 확인 및 생성
        EnsureManager<WaveManager>("WaveManager");
        EnsureManager<UIManager>("UIManager");
        EnsureManager<UpgradeManager>("UpgradeManager");
        EnsureManager<MonsterSpawn>("MonsterSpawn");

        // 2. 기본 UI (Canvas/EventSystem) 확인
        EnsureEventSystem();
        EnsureCanvas();

        Debug.Log("PJ1: Standard Scene Setup Complete.");
    }

    private static T EnsureManager<T>(string name) where T : MonoBehaviour
    {
        T manager = Object.FindAnyObjectByType<T>();
        if (manager == null)
        {
            GameObject go = new GameObject(name);
            manager = go.AddComponent<T>();
            Undo.RegisterCreatedObjectUndo(go, "Create " + name);
            Debug.Log($"PJ1: Created {name}");
        }
        return manager;
    }

    private static void EnsureEventSystem()
    {
        if (Object.FindAnyObjectByType<UnityEngine.EventSystems.EventSystem>() == null)
        {
            GameObject es = new GameObject("EventSystem");
            es.AddComponent<UnityEngine.EventSystems.EventSystem>();
            es.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
            Undo.RegisterCreatedObjectUndo(es, "Create EventSystem");
        }
    }

    private static void EnsureCanvas()
    {
        if (Object.FindAnyObjectByType<Canvas>() == null)
        {
            GameObject canvas = new GameObject("Canvas");
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.AddComponent<UnityEngine.UI.CanvasScaler>();
            canvas.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            canvas.layer = 5; // UI Layer
            Undo.RegisterCreatedObjectUndo(canvas, "Create Canvas");
        }
    }
}

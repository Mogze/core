using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Mogze.Core
{
    public class EditorBasics : EditorWindow
    {
        void OnGUI()
        {
            EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);
        }

        [MenuItem("Mogze/Start Scene Picker")]
        static void Open()
        {
            GetWindow<EditorBasics>();
        }

        [MenuItem("Mogze/Clear All")]
        static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
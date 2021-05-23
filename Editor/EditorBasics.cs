using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Mogze.Core
{
    public class EditorBasics
    {
        [MenuItem("Mogze/Clear All")]
        static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
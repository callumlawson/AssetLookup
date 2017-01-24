using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public static class ScriptableObjectUtilities
    {
        public static T GetScriptableObject<T>() where T : ScriptableObject
        {
            var assetPath = GetPath<T>();

            var possibleAsset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(T));
            if (possibleAsset)
            {
                return possibleAsset as T;
            }
            return CreateSettingsAsset(assetPath, ScriptableObject.CreateInstance<T>());
        }

        private static T CreateSettingsAsset<T>(string assetPath, T assetSettings) where T : ScriptableObject
        {
            AssetDatabase.CreateAsset(assetSettings, assetPath);
            AssetDatabase.SaveAssets();
            return assetSettings;
        }

        public static void SaveSettings<T>(T settings) where T : ScriptableObject
        {
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }

        private static string GetPath<T>() where T : ScriptableObject
        {
            return "Assets/Editor/EditorSettings/" + typeof(T) + ".asset";
        }
    }
}
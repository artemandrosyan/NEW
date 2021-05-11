using System;
using System.Linq;
using System.Reflection;
using UnityBuilderAction.Input;
using UnityBuilderAction.Reporting;
using UnityBuilderAction.Versioning;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UnityBuilderAction
{


public class Builder
{
    static string[] SCENES = FindEnabledEditorScenes ();

    static string APP_NAME = "LuauUnity";
    static string TARGET_DIR = "target";

    [MenuItem ("Custom/CI/Build iOS")]
    static void PerformIOSBuild ()
    {
        GenericBuild (SCENES, TARGET_DIR + "/ios/", BuildTarget.iOS, BuildOptions.None);
    }

    [MenuItem ("Custom/CI/Build Android")]
    static void PerformAndroidBuild ()
    {
        GenericBuild (SCENES, TARGET_DIR + "/android/", BuildTarget.Android, BuildOptions.AcceptExternalModificationsToPlayer);
    }

    private static string[] FindEnabledEditorScenes ()
    {
        List<string> EditorScenes = new List<string> ();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
            if (!scene.enabled)
                continue;
            EditorScenes.Add (scene.path);
        }
        return EditorScenes.ToArray ();
    }

    static void GenericBuild (string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget (build_target);
        string res = BuildPipeline.BuildPlayer (scenes, target_dir, build_target, build_options);
        if (res.Length > 0) {
            throw new Exception ("BuildPlayer failure: " + res);
        }
    }
}
}

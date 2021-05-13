using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
//using UnityEditor;
//using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UnityBuilderAction{
public class Builder {
  static string[] SCENES = FindEnabledEditorScenes();

  static string TARGET_DIR = "./";


  static void PerformIOSBuild() {
    GenericBuild(SCENES, TARGET_DIR + "/ios/", UnityEditor.BuildTarget.iOS, UnityEditor.BuildOptions.None);
  }


  static void PerformAndroidBuild() {
    UnityEditor.EditorUserBuildSettings.exportAsGoogleAndroidProject = true;
    GenericBuild(SCENES, "android/", UnityEditor.BuildTarget.Android, UnityEditor.BuildOptions.None);
   
  }

  private static string[] FindEnabledEditorScenes() {
    List<string> EditorScenes = new List<string>();
    foreach (UnityEditor.EditorBuildSettingsScene scene in UnityEditor.EditorBuildSettings.scenes) {
      if (!scene.enabled)
        continue;
      EditorScenes.Add(scene.path);
    }
    return EditorScenes.ToArray();
  }

  static void GenericBuild(string[] scenes, string target_dir, UnityEditor.BuildTarget build_target, UnityEditor.BuildOptions build_options) {
    UnityEditor.EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);

    // Perform build
    UnityEditor.Build.Reporting.BuildReport buildReport = UnityEditor.BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
    UnityEditor.Build.Reporting.BuildSummary summary = buildReport.summary;
     
    Console.WriteLine(summary.outputPath);
    Debug.Log(summary.outputPath);

    UnityEditor.Build.Reporting.BuildResult result = summary.result;
    Console.WriteLine(result.ToString());
     
  }
}
}

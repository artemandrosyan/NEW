using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

namespace UnityBuilderAction
{
static class CIEditorScript
{
	static string[] SCENES = FindEnabledEditorScenes ();

	static string APP_NAME = "LuauUnity";
	static string TARGET_DIR = ".";

	[MenuItem ("Custom/CI/Build iOS")]
	public static void PerformIOSBuild ()
	{
		GenericBuild (SCENES, TARGET_DIR + "/ios/", BuildTarget.iOS, BuildOptions.None);
	}

	[MenuItem ("Custom/CI/Build Android")]
	public static void PerformAndroidBuild ()
	{
		GenericBuild (SCENES, TARGET_DIR + "/android/", BuildTarget.Android, BuildOptions.AcceptExternalModificationsToPlayer);
	}

	public static string[] FindEnabledEditorScenes ()
	{
		List<string> EditorScenes = new List<string> ();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (!scene.enabled)
				continue;
			EditorScenes.Add (scene.path);
		}
		return EditorScenes.ToArray ();
	}

	public static void GenericBuild (string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (build_target);
   
		// Perform build
      BuildReport buildReport =  BuildPipeline.BuildPlayer (scenes, target_dir, build_target, build_options);

      // Summary
      BuildSummary summary = buildReport.summary;
      StdOutReporter.ReportSummary(summary);

      // Result
      BuildResult result = summary.result;
      StdOutReporter.ExitWithResult(result);
	}
}
}

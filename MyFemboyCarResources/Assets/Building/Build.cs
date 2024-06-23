using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Linq;

public class Build {

	[MenuItem("Building/Build Asset Bundles")]
	public static void BuildAssetBundles()
	{
		var path = Path.Combine(Application.dataPath, "Building/AssetBundles");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		
		if (CheckUnicodeCharacters(path))
		{
			Debug.LogWarning("AssetBundles path contains unicode characters. Compression will fail and was disabled.");
			BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
			return;
		}
		
		BuildPipeline.BuildAssetBundles(path);
	}

	internal static bool CheckUnicodeCharacters(string str)
	{
		return str.Any(x => x > 255);
	}
}

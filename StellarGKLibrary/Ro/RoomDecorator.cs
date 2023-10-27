using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoomDecorator
{
	public class RoomDecorator : SingletonMonoBehaviour<RoomDecorator>
	{
		private IEnumerator Start()
		{
			if (!AssetBundleManager.HasAssetBundle("CommanderAtlas.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CommanderAtlas.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CommanderAtlas.assetbundle"))
			{
				commanderAtlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CommanderAtlas.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				commanderAtlas.spriteMaterial = Resources.Load<Material>("Atlas/CommanderAtlas");
			}
			if (!AssetBundleManager.HasAssetBundle("CommanderAtlas_2.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CommanderAtlas_2.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CommanderAtlas_2.assetbundle"))
			{
				commanderAtlas_2.replacement = AssetBundleManager.GetObjectFromAssetBundle("CommanderAtlas_2.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				commanderAtlas_2.spriteMaterial = Resources.Load<Material>("Atlas/CommanderAtlas_2");
			}
			if (!AssetBundleManager.HasAssetBundle("CostumeIcon_1.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CostumeIcon_1.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CostumeIcon_1.assetbundle"))
			{
				costumeIcon_1Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CostumeIcon_1.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				costumeIcon_1Atlas.spriteMaterial = Resources.Load<Material>("Atlas/CostumeIcon_1");
			}
			if (!AssetBundleManager.HasAssetBundle("CostumeIcon_2.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CostumeIcon_2.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CostumeIcon_2.assetbundle"))
			{
				costumeIcon_2Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CostumeIcon_2.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				costumeIcon_2Atlas.spriteMaterial = Resources.Load<Material>("Atlas/CostumeIcon_2");
			}
			if (!AssetBundleManager.HasAssetBundle("CostumeIcon_3.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CostumeIcon_3.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CostumeIcon_3.assetbundle"))
			{
				costumeIcon_3Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CostumeIcon_3.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				costumeIcon_3Atlas.spriteMaterial = Resources.Load<Material>("Atlas/CostumeIcon_3");
			}
			if (!AssetBundleManager.HasAssetBundle("CostumeIcon_4.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CostumeIcon_4.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CostumeIcon_4.assetbundle"))
			{
				costumeIcon_4Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CostumeIcon_4.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				costumeIcon_4Atlas.spriteMaterial = Resources.Load<Material>("Atlas/CostumeIcon_4");
			}
			if (!AssetBundleManager.HasAssetBundle("CostumeIcon_5.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("CostumeIcon_5.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("CostumeIcon_5.assetbundle"))
			{
				costumeIcon_5Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("CostumeIcon_5.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				costumeIcon_5Atlas.spriteMaterial = Resources.Load<Material>("Atlas/CostumeIcon_5");
			}
			if (!AssetBundleManager.HasAssetBundle("Icon.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("Icon.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("Icon.assetbundle"))
			{
				iconAtlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("Icon.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				iconAtlas.spriteMaterial = Resources.Load<Material>("Atlas/Icon");
			}
			if (!AssetBundleManager.HasAssetBundle("DormitoryTheme_1.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("DormitoryTheme_1.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("DormitoryTheme_1.assetbundle"))
			{
				dormitoryTheme_1Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("DormitoryTheme_1.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				dormitoryTheme_1Atlas.spriteMaterial = Resources.Load<Material>("Atlas/DormitoryTheme_1");
			}
			if (!AssetBundleManager.HasAssetBundle("DormitoryCostume_1.assetbundle"))
			{
				yield return base.StartCoroutine(PatchManager.Instance.LoadPrefabAssetBundle("DormitoryCostume_1.assetbundle", ECacheType.None));
			}
			if (AssetBundleManager.HasAssetBundle("DormitoryCostume_1.assetbundle"))
			{
				dormitoryCostume_1Atlas.replacement = AssetBundleManager.GetObjectFromAssetBundle("DormitoryCostume_1.assetbundle").GetComponent<UIAtlas>();
			}
			else
			{
				dormitoryCostume_1Atlas.spriteMaterial = Resources.Load<Material>("Atlas/DormitoryCostume_1");
			}
			GameBillingManager.init();
			yield return base.StartCoroutine(InitRoom());
			GameObject loading = GameObject.Find("Loading");
			if (loading != null)
			{
				loading.GetComponent<UILoading>().Out();
			}
			yield break;
		}

		private IEnumerator InitRoom()
		{
			_view = UnityEngine.Object.FindObjectOfType<RoomView>();
			_view.Init();
			yield return null;
			SingletonMonoBehaviour<GridManager>.Instance.Init();
			SingletonMonoBehaviour<AIManager>.Instance.Init();
			yield return null;
			yield return null;
			yield break;
		}

		public Tiles GetTiles()
		{
			if (_view == null)
			{
				return null;
			}
			return _view.tiles[0];
		}

		private void CreateRoom()
		{
			ReleaseRoom();
			string text = "Room_10x10";
			string text2 = string.Format("./AssetBundles/{0}.assetbundle", text);
			if (File.Exists(text2))
			{
				_bundle = AssetBundle.LoadFromFile(text2);
				if (_bundle != null)
				{
					string[] allScenePaths = _bundle.GetAllScenePaths();
					text = Path.GetFileNameWithoutExtension(allScenePaths[0]);
				}
			}
			SceneManager.LoadScene(text, LoadSceneMode.Additive);
			_activedRoomName = text;
		}

		private void ReleaseRoom()
		{
			if (!string.IsNullOrEmpty(_activedRoomName))
			{
				SceneManager.UnloadScene(_activedRoomName);
				_activedRoomName = string.Empty;
			}
			if (_bundle != null)
			{
				_bundle.Unload(true);
			}
			Resources.UnloadUnusedAssets();
		}

		public UIAtlas commanderAtlas;

		public UIAtlas commanderAtlas_2;

		public UIAtlas costumeIcon_1Atlas;

		public UIAtlas costumeIcon_2Atlas;

		public UIAtlas costumeIcon_3Atlas;

		public UIAtlas costumeIcon_4Atlas;

		public UIAtlas costumeIcon_5Atlas;

		public UIAtlas iconAtlas;

		public UIAtlas dormitoryTheme_1Atlas;

		public UIAtlas dormitoryCostume_1Atlas;

		private RoomView _view;

		private AssetBundle _bundle;

		private string _activedRoomName;
	}
}

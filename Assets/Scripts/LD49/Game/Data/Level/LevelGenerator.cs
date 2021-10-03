using System;
using UnityEditor;
using UnityEngine;
using Utils.Extensions;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour {
	[SerializeField] protected Transform    _prefabsContainer;
	[SerializeField] protected Transform    _player;
	[SerializeField] protected Color        _playerSpawnColor;
	[SerializeField] protected PrefabData[] _prefabs;
	[SerializeField] protected Texture2D    _levelTexture;
	[SerializeField] protected Transform    _ground;
	[SerializeField] protected Transform    _leftBorder;
	[SerializeField] protected Transform    _rightBorder;
	[SerializeField] protected Transform    _topBorder;
	[SerializeField] protected int          _borderWidth;
	[SerializeField] protected Transform    _pointerHit;

	[SerializeField] protected float _cameraOverviewDistanceWidthRatio;
	[SerializeField] protected float _cameraOverviewDistanceHeightRatio;

	[ContextMenu("Parse Level Image")] private void ParseLevelImage() => ParseLevelImage(_levelTexture);

	public void ParseLevelImage(Texture2D mapTexture) {
		_prefabsContainer.ClearChildren();

		_pointerHit.localScale = new Vector3(mapTexture.width, mapTexture.height, 1);
		_pointerHit.position = new Vector3(mapTexture.width / 2f - .5f, mapTexture.height / 2f - .5f, .5f);

		for (var i = 0; i < mapTexture.width; ++i)
		for (var j = 0; j < mapTexture.height; ++j) {
			var mapPixelColor = mapTexture.GetPixel(i, j);
			if (_playerSpawnColor == mapPixelColor) _player.position = new Vector3(i, j, 0);
			else if (_prefabs.TrySingle(t => t.color == mapPixelColor, out var prefabData)) {
				InstantiatePrefab(prefabData, new Vector3(i, j, 0));
			}
		}

		CameraOverview.target = new Vector3(mapTexture.width / 2f - .5f, mapTexture.height / 2f - .5f,
			Mathf.Min(-mapTexture.width * _cameraOverviewDistanceWidthRatio, -mapTexture.height * _cameraOverviewDistanceHeightRatio));

		_ground.localScale = new Vector3(mapTexture.width + 2 * _borderWidth, _borderWidth, 1);
		_ground.position = new Vector3(mapTexture.width / 2f - .5f, -_borderWidth / 2f - .5f, 0);
		_topBorder.localScale = new Vector3(mapTexture.width + 2 * _borderWidth, _borderWidth, 1);
		_topBorder.position = new Vector3(mapTexture.width / 2f - .5f, mapTexture.height + _borderWidth / 2f - .5f, 0);
		_leftBorder.localScale = new Vector3(_borderWidth, mapTexture.height + 2 * _borderWidth, 1);
		_leftBorder.position = new Vector3(-_borderWidth / 2f - .5f, mapTexture.height / 2f - .5f, 0);
		_rightBorder.localScale = new Vector3(_borderWidth, mapTexture.height + 2 * _borderWidth, 1);
		_rightBorder.position = new Vector3(mapTexture.width + _borderWidth / 2f - .5f, mapTexture.height / 2f - .5f, 0);
	}

	private void InstantiatePrefab(PrefabData data, Vector3 position) {
#if UNITY_EDITOR
		var instance = PrefabUtility.InstantiatePrefab(data.randomPrefab, _prefabsContainer) as GameObject;
#else
		var instance = Instantiate(data.randomPrefab, _prefabsContainer);
#endif
		instance.transform.position = position;
		instance.transform.rotation = data.GetRotation();
	}

	[Serializable]
	public class PrefabData {
		public enum Rotation {
			None    = 0,
			Free90  = 1,
			FreeAll = 2,
			FreeY90 = 3,
			FreeY   = 4
		}

		[SerializeField] protected Color        _color;
		[SerializeField] protected GameObject[] _prefabs;
		[SerializeField] protected Rotation     _rotation;

		public Color      color        => _color;
		public GameObject randomPrefab => _prefabs.Random();

		public Quaternion GetRotation() {
			switch (_rotation) {
				case Rotation.None: return Quaternion.identity;
				case Rotation.Free90: return Quaternion.Euler(Random.Range(0, 4) * 90, Random.Range(0, 4) * 90, Random.Range(0, 4) * 90);
				case Rotation.FreeAll: return Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
				case Rotation.FreeY90: return Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
				case Rotation.FreeY: return Quaternion.Euler(0, Random.Range(0, 360), 0);
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}
}
using System.Linq;
using LD49.Input;
using TMPro;
using UnityEngine;
using Utils.Extensions;

public class WriteInputUi : MonoBehaviour {
	private enum Type {
		Movement      = 0,
		Jump          = 1,
		Restart       = 2,
		ChangeCamera  = 3,
		Shoot         = 4,
		Telekinesis   = 5,
		StableCircuit = 6
	}

	[SerializeField] protected TMP_Text _text;

	private void Start() => _text.text = ReplaceMacros(_text.text);

	private static string ReplaceMacros(string text) {
		EnumUtils.ForEach<Type>(t => text = text.Replace($"[{t}]", GetText(t)));
		return text;
	}

	private static string GetText(Type type) {
		switch (type) {
			case Type.Movement: return $"You can move left and right with <b>{Inputs.controls.Player.Left.LocalisedKeyName()}</b> and <b>{Inputs.controls.Player.Right.LocalisedKeyName()}</b>.";
			case Type.Jump: return $"Jump with <b>{Inputs.controls.Player.Jump.LocalisedKeyName()}</b>.";
			case Type.Restart: return $"You can restart the level at any time by pressing <b>{Inputs.controls.Game.RestartLevel.LocalisedKeyName()}</b>.";
			case Type.ChangeCamera: return $"Change the camera behaviour with <b>{Inputs.controls.Player.SwitchCamera.LocalisedKeyName()}</b>.";
			case Type.Shoot: return $"You can shoot by pressing and holding <b>{Inputs.controls.Player.Fire.LocalisedKeyName()}</b>.";
			case Type.Telekinesis: return $"You use your telekinesis skills to move objects with <b>{Inputs.controls.Player.Telekinesis.LocalisedKeyName()}</b>.";
			case Type.StableCircuit: return $"Consume a stable circuit with <b>{Inputs.controls.Player.UseStableCircuit.LocalisedKeyName()}</b>.";
			default: return string.Empty;
		}
	}
}
using UnityEngine;
using UnityEngine.UI;

public class PeaceOrWarUi : MonoBehaviour {
	[SerializeField] protected Image  _image;
	[SerializeField] protected Sprite _peaceSprite;
	[SerializeField] protected Sprite _warSprite;

	public void SetPeace(bool peace) => _image.sprite = peace ? _peaceSprite : _warSprite;
}
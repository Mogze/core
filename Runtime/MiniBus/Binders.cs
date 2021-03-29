using System;
using UnityEngine;
using UnityEngine.UI;
using EventData = System.Collections.Generic.Dictionary<string, object>;

namespace zehreken.i_cheat.MiniBus
{
	public class TextStringBinder : Bindable<Text, string>
	{
		public TextStringBinder(Text obj) : base(obj)
		{
		}

		public override void Update(string value)
		{
			obj.text = value;
		}
	}

	public class ImageSpriteBinder : Bindable<Image, Sprite>
	{
		public ImageSpriteBinder(Image obj) : base(obj)
		{
		}

		public override void Update(Sprite value)
		{
			obj.sprite = value;
		}
	}

	public class ImageFillBinder : Bindable<Image, float>
	{
		public ImageFillBinder(Image obj) : base(obj)
		{
		}


		public override void Update(float value)
		{
			value = Mathf.Clamp01(value);
			obj.fillAmount = value;
		}
	}

	public class GObjectBoolBinder : Bindable<GameObject, bool>
	{
		public GObjectBoolBinder(GameObject obj) : base(obj)
		{
		}

		public override void Update(bool value)
		{
			obj.SetActive(value);
		}
	}

	public class ActionEventBinder : Bindable<Action<EventData>, EventData>
	{
		public ActionEventBinder(Action<EventData> obj) : base(obj)
		{
		}

		public override void Update(EventData value)
		{
			obj(value);
		}
	}
}
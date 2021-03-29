using System;
using UnityEngine;
using UnityEngine.UI;
using EventData = System.Collections.Generic.Dictionary<string, object>;

namespace zehreken.i_cheat.MiniBus
{
	public static class BindingExtensions
	{
		// Extensions TextToString
		public static void Bind(this Text textMesh, GameEvent e)
		{
			Bus<Text, string>.SubscribeTo(e, new TextStringBinder(textMesh));
		}

		public static void Unbind(this Text textMesh, GameEvent e)
		{
			Bus<Text, string>.UnsubscribeFrom(e, new TextStringBinder(textMesh));
		}

		public static void Publish(GameEvent e, string value)
		{
			Bus<Text, string>.Publish(e, value);
		}

		// Extensions ImageToSprite
		public static void Bind(this Image image, GameEvent e)
		{
			Bus<Image, Sprite>.SubscribeTo(e, new ImageSpriteBinder(image));
		}

		public static void Unbind(this Image image, GameEvent e)
		{
			Bus<Image, Sprite>.UnsubscribeFrom(e, new ImageSpriteBinder(image));
		}

		public static void Publish(GameEvent e, Sprite value)
		{
			Bus<Image, Sprite>.Publish(e, value);
		}

		// Extensions ImageToFloat
		public static void BindFill(this Image image, GameEvent e)
		{
			Bus<Image, float>.SubscribeTo(e, new ImageFillBinder(image));
		}

		public static void UnbindFill(this Image image, GameEvent e)
		{
			Bus<Image, float>.UnsubscribeFrom(e, new ImageFillBinder(image)); // new instance is wrong
		}

		public static void PublishFill(GameEvent e, float value)
		{
			Bus<Image, float>.Publish(e, value);
		}

		// Extensions GameObjectToBool
		public static void Bind(this GameObject obj, GameEvent e)
		{
			Bus<GameObject, bool>.SubscribeTo(e, new GObjectBoolBinder(obj));
		}

		public static void Unbind(this GameObject obj, GameEvent e)
		{
			Bus<GameObject, bool>.UnsubscribeFrom(e, new GObjectBoolBinder(obj)); // new instance is wrong
		}

		public static void Publish(GameEvent e, bool value)
		{
			Bus<GameObject, bool>.Publish(e, value);
		}

		// Extensions ActionToData
		public static void Bind(this Action<EventData> obj, GameEvent e)
		{
			Bus<Action<EventData>, EventData>.SubscribeTo(e, new ActionEventBinder(obj));
		}

		public static void Unbind(this Action<EventData> obj, GameEvent e)
		{
			Bus<Action<EventData>, EventData>.UnsubscribeFrom(e, new ActionEventBinder(obj));
		}

		public static void Publish(GameEvent e, EventData value)
		{
			Bus<Action<EventData>, EventData>.Publish(e, value);
		}
	}
}
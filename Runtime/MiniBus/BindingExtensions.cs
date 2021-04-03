using System;
using UnityEngine;
using UnityEngine.UI;
using EventData = System.Collections.Generic.Dictionary<string, object>;

namespace Mogze.Core.MiniBus
{
	public static class BindingExtensions
	{
		// Extensions TextToString
		public static void Bind<T>(this Text textMesh) where T : IMessage
		{
			BindingBus<Text, string>.SubscribeTo<T>(new TextStringBinder(textMesh));
		}

		public static void Unbind<T>(this Text textMesh) where T : IMessage
		{
			BindingBus<Text, string>.UnsubscribeFrom<T>(new TextStringBinder(textMesh));
		}

		public static void Publish<T>(string value) where T : IMessage
		{
			BindingBus<Text, string>.Publish<T>(value);
		}

		// Extensions ImageToSprite
		public static void Bind<T>(this Image image) where T : IMessage
		{
			BindingBus<Image, Sprite>.SubscribeTo<T>(new ImageSpriteBinder(image));
		}

		public static void Unbind<T>(this Image image) where T : IMessage
		{
			BindingBus<Image, Sprite>.UnsubscribeFrom<T>( new ImageSpriteBinder(image));
		}

		public static void Publish<T>(Sprite value) where T : IMessage
		{
			BindingBus<Image, Sprite>.Publish<T>(value);
		}

		// Extensions ImageToFloat
		public static void BindFill<T>(this Image image) where T : IMessage
		{
			BindingBus<Image, float>.SubscribeTo<T>(new ImageFillBinder(image));
		}

		public static void UnbindFill<T>(this Image image) where T : IMessage
		{
			BindingBus<Image, float>.UnsubscribeFrom<T>(new ImageFillBinder(image)); // new instance is wrong
		}

		public static void PublishFill<T>(float value) where T : IMessage
		{
			BindingBus<Image, float>.Publish<T>(value);
		}

		// Extensions GameObjectToBool
		public static void Bind<T>(this GameObject obj) where T : IMessage
		{
			BindingBus<GameObject, bool>.SubscribeTo<T>(new GObjectBoolBinder(obj));
		}

		public static void Unbind<T>(this GameObject obj) where T : IMessage
		{
			BindingBus<GameObject, bool>.UnsubscribeFrom<T>(new GObjectBoolBinder(obj)); // new instance is wrong
		}

		public static void Publish<T>(bool value) where T : IMessage
		{
			BindingBus<GameObject, bool>.Publish<T>(value);
		}

		// Extensions ActionToData
		public static void Bind<T>(this Action<EventData> obj) where T : IMessage
		{
			BindingBus<Action<EventData>, EventData>.SubscribeTo<T>(new ActionEventBinder(obj));
		}

		public static void Unbind<T>(this Action<EventData> obj) where T : IMessage
		{
			BindingBus<Action<EventData>, EventData>.UnsubscribeFrom<T>(new ActionEventBinder(obj));
		}

		public static void Publish<T>(EventData value) where T : IMessage
		{
			BindingBus<Action<EventData>, EventData>.Publish<T>(value);
		}
	}
}
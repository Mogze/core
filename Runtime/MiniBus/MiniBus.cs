using System;
using System.Collections.Generic;

namespace Mogze.Core.MiniBus
{
	public static class MiniBus
	{
		private static readonly Dictionary<Type, List<Action<IMessage>>> eventToActionMap = new Dictionary<Type, List<Action<IMessage>>>();

		public static void SubscribeToEvent<T>(Action<IMessage> a) where T : IMessage
		{
            var t = typeof(T);
			if (!eventToActionMap.ContainsKey(t))
			{
				eventToActionMap.Add(t, new List<Action<IMessage>>());
			}

			eventToActionMap[t].Add(a);
		}

		public static void UnsubscribeFromEvent<T>(Action<IMessage> a) where T : IMessage
		{
            var t = typeof(T);
			if (eventToActionMap.ContainsKey(t))
			{
				eventToActionMap[t].Remove(a);
			}
		}

		public static void PublishEvent<T>(IMessage data = null) where T : IMessage
		{
            var t = typeof(T);
			if (eventToActionMap.ContainsKey(t))
			{
				foreach (var action in eventToActionMap[t])
				{
					action(data);
				}
			}
		}
	}
}
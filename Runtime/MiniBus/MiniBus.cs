using System;
using System.Collections.Generic;

namespace Mogze.Core.MiniBus
{
	public static class MiniBus
	{
		private static readonly Dictionary<GameEvent, List<Action<IMessage>>> eventToActionMap = new Dictionary<GameEvent, List<Action<IMessage>>>();

		public static void SubscribeToEvent(GameEvent e, Action<IMessage> a)
		{
			if (!eventToActionMap.ContainsKey(e))
			{
				eventToActionMap.Add(e, new List<Action<IMessage>>());
			}

			eventToActionMap[e].Add(a);
		}

		public static void UnsubscribeFromEvent(GameEvent e, Action<IMessage> a)
		{
			if (eventToActionMap.ContainsKey(e))
			{
				eventToActionMap[e].Remove(a);
			}
		}

		public static void PublishEvent(GameEvent e, IMessage data = null)
		{
			if (eventToActionMap.ContainsKey(e))
			{
				foreach (var action in eventToActionMap[e])
				{
					action(data);
				}
			}
		}
	}
}
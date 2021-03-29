using System.Collections.Generic;

namespace zehreken.i_cheat.MiniBus
{
	public static class Bus<T, TData>
	{
		private static Dictionary<GameEvent, List<Bindable<T, TData>>> eventMap = new Dictionary<GameEvent, List<Bindable<T, TData>>>();

		public static void Publish(GameEvent e, TData value)
		{
			if (!eventMap.ContainsKey(e))
				return;

			foreach (var obj in eventMap[e])
			{
				obj.Update(value);
			}
		}

		public static void SubscribeTo(GameEvent e, Bindable<T, TData> obj)
		{
			if (!eventMap.ContainsKey(e))
			{
				eventMap.Add(e, new List<Bindable<T, TData>>());
			}

			Bindable<T, TData> temp = null;
			foreach (var bindable in eventMap[e])
			{
				if (bindable.Equals(obj))
				{
					temp = bindable;
					break;
				}
			}

			if (temp == null)
				eventMap[e].Add(obj);
		}

		public static void UnsubscribeFrom(GameEvent e, Bindable<T, TData> obj)
		{
			if (!eventMap.ContainsKey(e)) return;

			Bindable<T, TData> temp = null;
			foreach (var bindable in eventMap[e])
			{
				if (bindable.Equals(obj))
				{
					temp = bindable;
					break;
				}
			}

			if (temp != null)
			{
				{
					eventMap[e].Remove(temp);
				}
			}
		}
	}
}
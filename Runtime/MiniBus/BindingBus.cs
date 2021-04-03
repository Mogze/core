using System;
using System.Collections.Generic;

namespace Mogze.Core.MiniBus
{
	public static class BindingBus<TObj, TData>
	{
		private static Dictionary<Type, List<Bindable<TObj, TData>>> eventMap = new Dictionary<Type, List<Bindable<TObj, TData>>>();

		public static void Publish<T>(TData value) where T : IMessage
		{
            var t = typeof(T);
			if (!eventMap.ContainsKey(t))
				return;

			foreach (var obj in eventMap[t])
			{
				obj.Update(value);
			}
		}

		public static void SubscribeTo<T>(Bindable<TObj, TData> obj) where T : IMessage
		{
            var t = typeof(T);
			if (!eventMap.ContainsKey(t))
			{
				eventMap.Add(t, new List<Bindable<TObj, TData>>());
			}

			Bindable<TObj, TData> temp = null;
			foreach (var bindable in eventMap[t])
			{
				if (bindable.Equals(obj))
				{
					temp = bindable;
					break;
				}
			}

			if (temp == null)
				eventMap[t].Add(obj);
		}

		public static void UnsubscribeFrom<T>(Bindable<TObj, TData> obj) where T : IMessage
		{
            var t = typeof(T);
			if (!eventMap.ContainsKey(t)) return;

			Bindable<TObj, TData> temp = null;
			foreach (var bindable in eventMap[t])
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
					eventMap[t].Remove(temp);
				}
			}
		}
	}
}
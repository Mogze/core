using UnityEngine;
using System.Text;

namespace Mogze.Core.StringUtilities
{
	public static class StringExtensions
	{
		public static string Italic(this string s)
		{
			return $"<i>{s}</i>";
		}

		public static string Bold(this string s)
		{
			return $"<b>{s}</b>";
		}

		public static string Color(this string s, Color color)
		{
            var hexColor = ColorUtility.ToHtmlStringRGBA(color);
			return $"<color=#{hexColor}>{s}</color>";
		}

		public static string ToPrintable<T>(this T obj)
		{
            var sb = new StringBuilder("");
			var fields = typeof(T).GetFields();
			foreach (var fieldInfo in fields)
			{
                sb.Append($"{fieldInfo.Name}: {fieldInfo.GetValue(obj)}\n");
			}

			return sb.ToString();
		}
	}
}
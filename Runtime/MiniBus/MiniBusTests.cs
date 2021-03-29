using UnityEngine;
using UnityEngine.UI;

namespace zehreken.i_cheat.MiniBus
{
	public class MiniBusTests
	{
		// private Main main;
		// private int temp = 0;
		
		// public MiniBusTests(Main main)
		// {
		// 	this.main = main;

		// 	main.GetElements().text.Bind(GameEvent.UpdateText);
		// 	main.GetElements().image.Bind(GameEvent.UpdateImage);
		// 	main.GetElements().toggleObject.Bind(GameEvent.UpdateGObjectActive);
		// }

		// public void Update()
		// {
		// 	temp++;
			
		// 	Bus<Text, string>.Publish(GameEvent.UpdateText, temp.ToString());
		// 	Bus<Image, Sprite>.Publish(GameEvent.UpdateImage, temp % 20 < 10 ? main.GetElements().Sprite1 : main.GetElements().Sprite2);
		// 	Bus<GameObject, bool>.Publish(GameEvent.UpdateGObjectActive, temp % 20 < 10);
		// }

		// ~MiniBusTests()
		// {
		// 	Debug.Log("Unbinding");
		// 	main.GetElements().text.Unbind(GameEvent.UpdateText);
		// 	main.GetElements().image.Unbind(GameEvent.UpdateImage);
		// 	main.GetElements().toggleObject.Unbind(GameEvent.UpdateGObjectActive);
		// }
	}
}
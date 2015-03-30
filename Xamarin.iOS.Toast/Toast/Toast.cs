using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Xamarin.iOS.Toast
{
	/// <summary>
	/// The main class for displaying toasts, this class ensures that toasts dont overlap each other in the iOS app
	/// </summary>
	public static class Toast
	{
		static ToastView instance = null;
		static readonly object toast_lock = new object();

		/// <summary>
		/// Show a Toast with text as specified
		/// </summary>
		/// <param name="text">Text.</param>
		public static void Show(string text)
		{
			Show(text, 4000);
		}

		/// <summary>
		/// Show a Toast with text as specified, can set duration
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="durationMilliseonds">Duration milliseonds.</param>
		public static void Show(string text, int durationMilliseonds)
		{
			lock(toast_lock)
			{
				if (instance != null) instance.Remove();
				instance = new ToastView(text, durationMilliseonds);
				instance.Show();
			}
		}

		/// <summary>
		/// Hide the Toast.
		/// </summary>
		public static void Hide()
		{
			lock(toast_lock)
			{
				if (instance != null) instance.Remove();
			}
		}
	}
}


using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Xamarin.iOS.Toast
{
	/// <summary>
	/// Underlying class to control the toast display
	/// </summary>
	public class ToastView : NSObject
	{
		ToastSettings theSettings = new ToastSettings ();

		protected int offsetLeft = 0;
		protected int offsetTop = 0;
		private string text = null;
		private UIView view;

		public ToastView (string Text, int durationMilliseonds)
		{
			text = Text;
			theSettings.Duration = durationMilliseonds;
		}
		/// <summary>
		/// Sets the gravity.
		/// </summary>
		/// <returns>The gravity.</returns>
		/// <param name="gravity">Gravity.</param>
		/// <param name="OffSetLeft">Off set left.</param>
		/// <param name="OffSetTop">Off set top.</param>
		public ToastView SetGravity (ToastGravity gravity, int OffSetLeft, int OffSetTop)
		{
			theSettings.Gravity = gravity;
			offsetLeft = OffSetLeft;
			offsetTop = OffSetTop;
			return this;
		}

		/// <summary>
		/// Sets the position.
		/// </summary>
		/// <returns>The position.</returns>
		/// <param name="Position">Position.</param>
		public ToastView SetPosition (PointF Position)
		{
			theSettings.Position = Position;
			return this;
		}

		/// <summary>
		/// Create and display a toast
		/// </summary>
		public void Show ()
		{
			UIButton v = UIButton.FromType (UIButtonType.Custom);
			view = v;

			UIFont font = UIFont.BoldSystemFontOfSize (14F);
			SizeF textSize = view.StringSize (text, font, new SizeF (280, 60));

			UILabel label = new UILabel (new RectangleF (0, 0, textSize.Width, textSize.Height));
			label.BackgroundColor = UIColor.Clear;
			label.TextColor = UIColor.Black;
			label.Font = font;
			label.Text = text;
			label.Lines = 0;
			label.ShadowColor = UIColor.Clear;
			label.ShadowOffset = new SizeF (1, 1);

			v.Frame = new RectangleF (0, 0, textSize.Width + 16, textSize.Height + 14);
			label.Center = new PointF (v.Frame.Size.Width / 2, v.Frame.Height / 2);
			v.AddSubview (label);

			v.BackgroundColor = UIColor.FromRGBA (1, 1, 1, 0.95f);
			v.Layer.CornerRadius = 5;

			UIWindow window = UIApplication.SharedApplication.Windows[0];

			PointF point = new PointF (window.Frame.Size.Width / 2, window.Frame.Size.Height / 2);

			if (theSettings.Gravity == ToastGravity.Top)
			{
				point = new PointF (window.Frame.Size.Width / 2, 100);
			}
			else if (theSettings.Gravity == ToastGravity.Bottom)
			{
				point = new PointF (window.Frame.Size.Width / 2, window.Frame.Size.Height - 80);
			}
			else if (theSettings.Gravity == ToastGravity.Center)
			{
				point = new PointF (window.Frame.Size.Width / 2, window.Frame.Size.Height / 2);
			}
			else
			{
				point = theSettings.Position;
			}

			point = new PointF (point.X + offsetLeft, point.Y + offsetTop);
			v.Center = point;
			window.AddSubview (v);
			v.AllTouchEvents += delegate { HideToast (); };

			m_timer = NSTimer.CreateScheduledTimer (theSettings.DurationSeconds, this, new Selector ("HideToast"), null, false);

		}
		private NSTimer m_timer = null;

		[ExportAttribute("HideToast")]
		void HideToast ()
		{
			UIView.BeginAnimations ("");
			view.Alpha = 0;
			UIView.CommitAnimations ();
		}

		/// <summary>
		/// Remove individual toast
		/// </summary>
		void RemoveToast ()
		{
			view.RemoveFromSuperview ();
		}

		/// <summary>
		// Remove all toasts
		/// </summary>
		public void Hide()
		{
			m_timer.Invalidate();
			RemoveToast();
		}

		/// <summary>
		/// Remove toast
		/// </summary>
		public void Remove()
		{
			this.Hide();
			this.Dispose();
		}

	}

}


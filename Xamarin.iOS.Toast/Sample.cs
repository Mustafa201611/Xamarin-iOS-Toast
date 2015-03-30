
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Xamarin.iOS.Toast
{
	public partial class Sample : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Sample ()
			: base (UserInterfaceIdiomIsPhone ? "Sample_iPhone" : "Sample_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = UIColor.Gray;
		}

		public override void ViewDidAppear (bool animated)
		{
			// Example toasts 
			Toast.Show ("The problem with trouble shooting is that trouble shoots back.");
//			Toast.Show ("If at first you don't succeed, redefine success.");
//			Toast.Show ("Failure is not an option. It's bundled with your software.");
//			Toast.Show ("A dog has an owner. A cat has a staff.");
//			Toast.Show ("99 percent of lawyers give the rest a bad name.", 5000);

		}
	}
}


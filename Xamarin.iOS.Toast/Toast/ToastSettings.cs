using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Xamarin.iOS.Toast
{
	/// <summary>
	/// Toast settings, default duration etc.
	/// </summary>
    public class ToastSettings
    {
        public ToastSettings ()
        {
            this.Duration = 3000;
            this.Gravity = ToastGravity.Bottom;
        }

        public int Duration
        {
            get;
            set;
        }

        public double DurationSeconds
        {
            get { return (double) Duration/1000 ;}

        }

        public ToastGravity Gravity
        {
            get;
            set;
        }

        public PointF Position
        {
            get;
            set;
        }
	}

	/// <summary>
	/// Toast gravity (floating position on screen).
	/// </summary>
	public enum ToastGravity
	{
	    Top = 0,
	    Bottom = 1,
	    Center = 2
	}
}


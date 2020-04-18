using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using FFImageLoading.Forms.Platform;
using Foundation;
using FreeChat.Helpers;
using FreeChat.Helpers.MyEventArgs;
using Lottie.Forms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;

namespace FreeChat.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        NSObject _onKeyboardShowObserver;
        NSObject _onKeyboardHideObserver;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental", "SwipeView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();
            XamEffects.iOS.Effects.Init();

            AnimationViewRenderer.Init();

            LoadApplication(new App());

            RegisterKeyBoardObserver();

            return base.FinishedLaunching(app, options);
        }

        void RegisterKeyBoardObserver()
        {
            if (_onKeyboardShowObserver == null)
                _onKeyboardShowObserver = UIKeyboard.Notifications.ObserveWillShow((object sender, UIKeyboardEventArgs args) =>
                {
                    NSValue result = (NSValue)args.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
                    CGSize keyboardSize = result.RectangleFValue.Size;
                    MessagingCenter.Send<object, KeyboardAppearEventArgs>(this, Constants.iOSKeyboardAppears, new KeyboardAppearEventArgs { KeyboardSize = (float)keyboardSize.Height });
                });
            if (_onKeyboardHideObserver == null)
                _onKeyboardHideObserver = UIKeyboard.Notifications.ObserveWillHide((object sender, UIKeyboardEventArgs args) =>
                    MessagingCenter.Send<object, string>(this, Constants.iOSKeyboardDisappears, Constants.iOSKeyboardDisappears));
        }

        
        public override void WillTerminate(UIApplication application)
        {
            if (_onKeyboardShowObserver == null)
            {
                _onKeyboardShowObserver.Dispose();
                _onKeyboardShowObserver = null;
            }

            if (_onKeyboardHideObserver == null)
            {
                _onKeyboardHideObserver.Dispose();
                _onKeyboardHideObserver = null;
            }
        }
    }
}

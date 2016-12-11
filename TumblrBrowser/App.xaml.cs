using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using TumblrBrowser.Pages;

namespace TumblrBrowser
{
  public sealed partial class App: Application
  {
    private TransitionCollection transitions;
    
    public App( )
    {
      this.InitializeComponent( );
      this.Suspending += this.OnSuspending;

      Dependencies.Initialize();

      HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }

    private void HardwareButtons_BackPressed( object sender, BackPressedEventArgs e )
    {
      Frame rootFrame = Window.Current.Content as Frame;
      if( rootFrame.CanGoBack )
      {
        e.Handled = true;
        rootFrame.GoBack();
      }
    }

    protected override void OnLaunched( LaunchActivatedEventArgs e )
    {
#if DEBUG
      if( Debugger.IsAttached )
      {
        this.DebugSettings.EnableFrameRateCounter = true;
      }
#endif

      Frame rootFrame = Window.Current.Content as Frame;
      
      if( rootFrame == null )
      {
        rootFrame = new Frame( );
        
        rootFrame.CacheSize = 1;
        
        rootFrame.Language = ApplicationLanguages.Languages[ 0 ];

        if( e.PreviousExecutionState == ApplicationExecutionState.Terminated )
        {
        }
        
        Window.Current.Content = rootFrame;
      }
      
      if( rootFrame.Content == null )
      {
        if( rootFrame.ContentTransitions != null )
        {
          this.transitions = new TransitionCollection( );
          foreach( var c in rootFrame.ContentTransitions )
          {
            this.transitions.Add( c );
          }
        }

        rootFrame.ContentTransitions = null;
        rootFrame.Navigated += this.RootFrame_FirstNavigated;
        
        if( !rootFrame.Navigate( typeof( PostsListPage ), e.Arguments ) )
        {
          throw new Exception( "Failed to create initial page" );
        }
      }

      Window.Current.Activate( );
    }
    
    private void RootFrame_FirstNavigated( object sender, NavigationEventArgs e )
    {
      var rootFrame = sender as Frame;
      rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection( ) { new NavigationThemeTransition( ) };
      rootFrame.Navigated -= this.RootFrame_FirstNavigated;
    }
    
    private void OnSuspending( object sender, SuspendingEventArgs e )
    {
      var deferral = e.SuspendingOperation.GetDeferral( );
      
      deferral.Complete( );
    }
  }
}
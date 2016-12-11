using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using TumblrBrowser.Pages;
using TumblrBrowser.Portable.Navigation;
using TumblrBrowser.Portable.Services;
using TumblrBrowser.Portable.Services.PostParser;
using TumblrBrowser.Portable.ViewModel;
using TumblrBrowser.Services;

namespace TumblrBrowser
{
  internal static class Dependencies
  {
    public static void Initialize( )
    {
      ServiceLocator.SetLocatorProvider( ( ) => SimpleIoc.Default );

      RegisterNavigation( );
      RegisterServices( );
      ViewModelLocator.RegisterViewModels( );
    }

    /// <summary>
    /// Associate page types with their keys used inside the INavigation facade
    /// </summary>
    public static void RegisterNavigation( )
    {
      var navigationService = new NavigationService( );
      navigationService.Configure( Navigation.PhotoPage, typeof( PhotoPage ) );
      navigationService.Configure( Navigation.QuotePage, typeof( QuotePage ) );
      navigationService.Configure( Navigation.LinkPage, typeof( LinkPostPage ) );
      navigationService.Configure( Navigation.RegularPostPage, typeof( RegularPostPage ) );
      navigationService.Configure( Navigation.VideoPage, typeof( VideoPostPage ) );
      navigationService.Configure( Navigation.AudioPage, typeof( AudioPostPage ) );
      navigationService.Configure( Navigation.ConversationPage, typeof( ConversationPostPage ) );
      navigationService.Configure( Navigation.AnswerPage, typeof( AnswerPostPage ) );

      SimpleIoc.Default.Register<INavigationService>( ( ) => navigationService );
      SimpleIoc.Default.Register<INavigation, Navigation>( );
    }

    private static void RegisterServices( )
    {
      SimpleIoc.Default.Register<ITumblrApiService, TumblrApiService>( );
      SimpleIoc.Default.Register<IPostParser, PostParser>( );
      SimpleIoc.Default.Register<ISettingsManager, SettingsManager>( );
      SimpleIoc.Default.Register<IUriLauncher, UriLauncher>( );
    }
  }
}
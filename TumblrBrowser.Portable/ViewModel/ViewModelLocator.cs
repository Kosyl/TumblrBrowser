using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TumblrBrowser.Portable.ViewModel
{
  /// <summary>
  /// Static asscess to ViewModel instances
  /// </summary>
  public static class ViewModelLocator
  {
    public static void RegisterViewModels( )
    {
      SimpleIoc.Default.Register<PostsListViewModel>( );
      SimpleIoc.Default.Register<PhotoViewModel>( );
      SimpleIoc.Default.Register<LinkViewModel>( );
      SimpleIoc.Default.Register<QuoteViewModel>( );
      SimpleIoc.Default.Register<RegularPostViewModel>( );
      SimpleIoc.Default.Register<VideoViewModel>( );
      SimpleIoc.Default.Register<AudioViewModel>( );
      SimpleIoc.Default.Register<ConversationViewModel>( );
      SimpleIoc.Default.Register<AnswerViewModel>( );
    }

    public static PostsListViewModel PostsList => ServiceLocator.Current.GetInstance<PostsListViewModel>( );

    public static PhotoViewModel Photo => ServiceLocator.Current.GetInstance<PhotoViewModel>( );
    public static RegularPostViewModel RegularPost => ServiceLocator.Current.GetInstance<RegularPostViewModel>( );
    public static LinkViewModel Link => ServiceLocator.Current.GetInstance<LinkViewModel>( );
    public static QuoteViewModel Quote => ServiceLocator.Current.GetInstance<QuoteViewModel>( );
    public static VideoViewModel Video => ServiceLocator.Current.GetInstance<VideoViewModel>( );
    public static AudioViewModel Audio => ServiceLocator.Current.GetInstance<AudioViewModel>( );
    public static ConversationViewModel Conversation => ServiceLocator.Current.GetInstance<ConversationViewModel>( );
    public static AnswerViewModel Answer => ServiceLocator.Current.GetInstance<AnswerViewModel>( );
  }
}
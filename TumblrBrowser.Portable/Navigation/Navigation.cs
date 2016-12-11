using System;
using GalaSoft.MvvmLight.Views;
using TumblrBrowser.Portable.Model;

namespace TumblrBrowser.Portable.Navigation
{
  public class Navigation: INavigation
  {
    //Page identifiers
    public const string RegularPostPage = nameof( RegularPostPage );
    public const string LinkPage = nameof( LinkPage );
    public const string QuotePage = nameof( QuotePage );
    public const string PhotoPage = nameof( PhotoPage );
    public const string VideoPage = nameof( VideoPage );
    public const string AnswerPage = nameof( AnswerPage );
    public const string AudioPage = nameof( AudioPage );
    public const string ConversationPage = nameof( ConversationPage );

    private INavigationService navService;

    public Navigation( INavigationService navService )
    {
      this.navService = navService;
    }

    /// <summary>
    /// Navigate to the page showing selected post. Target page type is chosen depending on the post type.
    /// </summary>
    /// <param name="post">Post to show</param>
    public void ShowPost( PostBase post )
    {
      switch( post.PostType )
      {
        case PostType.Regular:
          this.navService.NavigateTo( RegularPostPage, post );
          return;
        case PostType.Link:
          this.navService.NavigateTo( LinkPage, post );
          return;
        case PostType.Answer:
          this.navService.NavigateTo( AnswerPage, post );
          return;
        case PostType.Quote:
          this.navService.NavigateTo( QuotePage, post );
          return;
        case PostType.Photo:
          this.navService.NavigateTo( PhotoPage, post );
          return;
        case PostType.Video:
          this.navService.NavigateTo( VideoPage, post );
          return;
        case PostType.Audio:
          this.navService.NavigateTo( AudioPage, post );
          return;
        case PostType.Conversation:
          this.navService.NavigateTo( ConversationPage, post );
          return;
        default:
          throw new ArgumentOutOfRangeException( nameof( PostBase.PostType ), "Unrecognized post type" );
      }
    }
  }
}
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;
using TumblrBrowser.Portable.Utils;

namespace TumblrBrowser.Portable.ViewModel
{
  /// <summary>
  /// Base class for ViewModels of single posts for different post types
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PostViewModel<T>: ViewModelBase where T: PostBase
  {
    protected IUriLauncher launcher;

    public ICommand LinkClickCommand => new TypedCommand<string>( this.LinkClick );

    private void LinkClick( string url )
    {
      this.launcher?.LaunchUri( url );
    }

    public PostViewModel( IUriLauncher launcher )
    {
      this.launcher = launcher;
    }
    
    public virtual void Activate( T newPost )
    {
      if( this.Post?.PostId != newPost?.PostId )
      {
        this.Post = newPost;
      }
    }

    public T Post
    {
      get
      {
        return this.post;
      }
      set
      {
        this.post = value;
        this.RaisePropertyChanged();
      }
    }
    private T post;
  }
}
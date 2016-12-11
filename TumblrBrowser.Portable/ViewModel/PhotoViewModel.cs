using System.Windows.Input;
using GalaSoft.MvvmLight;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Services;
using TumblrBrowser.Portable.Utils;

namespace TumblrBrowser.Portable.ViewModel
{
  public class PhotoViewModel: PostViewModel<PhotoPost>
  {
    public PhotoViewModel( IUriLauncher launcher ): base( launcher )
    {
    }

    public override void Activate( PhotoPost post )
    {
      base.Activate(post);

      //we wait for images to load, what will be signalled by invoking the SetReadyCommand
      this.Ready = false;
    }

    public ICommand SetReadyCommand => new ParameterlessCommand( this.SetReady );

    private void SetReady( )
    {
      this.Ready = true;
    }
    
    public bool Ready
    {
      get
      {
        return this.ready;
      }
      set
      {
        this.ready = value;
        this.RaisePropertyChanged( );
      }
    }
    private bool ready;
  }
}
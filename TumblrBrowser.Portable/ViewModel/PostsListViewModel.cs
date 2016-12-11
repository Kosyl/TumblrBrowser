using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TumblrBrowser.Portable.Model;
using TumblrBrowser.Portable.Navigation;
using TumblrBrowser.Portable.Services;
using TumblrBrowser.Portable.Utils;

namespace TumblrBrowser.Portable.ViewModel
{
  public class PostsListViewModel: ViewModelBase
  {
    //setting key for storing username
    private string LastUsernameSetting = nameof( LastUsernameSetting );

    public PostsListViewModel( ITumblrApiService tumblrService, ISettingsManager settings, INavigation navigation )
    {
      this.tumblrService = tumblrService;
      this.settings = settings;
      this.navigation = navigation;
    }

    public void Activate( bool cameBack )
    {
      if( !cameBack )
      {
        this.Username = this.settings.Get( this.LastUsernameSetting );
        this.LoadMoreObjects( );
      }
      else
      {
        //ignore, everything is loaded
      }
    }

    #region Fields and Properties

    private ITumblrApiService tumblrService;
    private ISettingsManager settings;
    private INavigation navigation;

    public ObservableCollection<PostBase> Posts
    {
      get
      {
        return this.posts;
      }
      set
      {
        this.posts = value;
        this.RaisePropertyChanged( );
      }
    }

    private ObservableCollection<PostBase> posts = new ObservableCollection<PostBase>();

    public bool Loading
    {
      get
      {
        return this.loading;
      }
      set
      {
        this.loading = value;
        this.RaisePropertyChanged();
      }
    }

    private bool loading;

    public string Username
    {
      get
      {
        return this.username;
      }
      set
      {
        this.username = value;
        this.RaisePropertyChanged( );
      }
    }

    private string username;

    public ICommand LoadObjectsCommand => new ParameterlessCommand( this.LoadMoreObjects );

    public ICommand RefreshListCommand => new ParameterlessCommand( this.RefreshList );

    public ICommand ItemClickCommand => new TypedCommand<PostBase>( this.ItemClick );

    #endregion

    private async void LoadMoreObjects( )
    {
      if( this.Loading || String.IsNullOrWhiteSpace(this.Username) )
        return;

      this.Loading = true;

      var posts = await this.tumblrService.FetchPosts( this.Username, this.Posts.Count, 20 );
      this.Posts.AddRange( posts );

      this.Loading = false;
    }

    private void RefreshList( )
    {
      this.Posts.Clear( );
      this.StoreUsername( );
      this.LoadMoreObjects();
    }

    private void StoreUsername( )
    {
      this.settings.Set( this.LastUsernameSetting, this.Username );
    }

    private void ItemClick( PostBase item )
    {
      this.navigation.ShowPost( item );
    }
  }
}
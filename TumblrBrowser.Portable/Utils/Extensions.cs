using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TumblrBrowser.Portable.Utils
{
  public static class Extensions
  {
    public static void AddRange<T>( this ObservableCollection<T> collection, IEnumerable<T> objects )
    {
      foreach( var o in objects ?? Enumerable.Empty<T>( ) )
      {
        collection.Add( o );
      }
    }
  }
}
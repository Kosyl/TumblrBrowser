using System;
using System.Windows.Input;

namespace TumblrBrowser.Portable.Utils
{
  /// <summary>
  /// Class implementing ICommand, that limits the command parameter to a specified type
  /// </summary>
  /// <typeparam name="T">Type of the object passed as the command parameter</typeparam>
  public class TypedCommand<T>: ICommand
  {
    private Action<T> action;

    public bool CanExecute( object parameter )
    {
      return true;
    }

    public void Execute( object parameter )
    {
      this.action?.Invoke( (T)parameter );
    }

    public event EventHandler CanExecuteChanged;

    public TypedCommand( Action<T> action )
    {
      this.action = action;
    }
  }
}

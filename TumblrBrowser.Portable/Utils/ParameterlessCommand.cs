using System;
using System.Windows.Input;

namespace TumblrBrowser.Portable.Utils
{
  public class ParameterlessCommand: ICommand
  {
    private Action action;

    public bool CanExecute( object parameter )
    {
      return true;
    }

    public void Execute( object parameter )
    {
      this.action?.Invoke( );
    }

    public event EventHandler CanExecuteChanged;

    public ParameterlessCommand( Action action )
    {
      this.action = action;
    }
  }
}
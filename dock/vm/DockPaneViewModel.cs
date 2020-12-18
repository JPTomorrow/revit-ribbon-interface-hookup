namespace JPMorrow.UI.ViewModels
{
    #region using
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.DB.Electrical;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Threading;
    using System.Windows;
    using MainApp;
    #endregion

    public partial class DockPaneModel : Presenter
    {
        //Commands
        public ICommand Command => new RelayCommand<Window>(SaveAndClose);
        public ICommand SaveAndCloseCmd => new RelayCommand<Window>(SaveAndClose);

        public string Current_Document_Text { get; set; }

        /// <summary>
        /// The Main View Model for RunTableView.xaml
        /// </summary>
        public DockPaneModel()
        {
        }


    }

    #region Inherited Classes
    public abstract class Presenter : INotifyPropertyChanged
    {
         public event PropertyChangedEventHandler PropertyChanged;

         protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Has_Data"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Run_ID"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Panel_Type"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("From"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("To"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Length"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Diameter"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Makeup"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Conduit_Type"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hardware_Name"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hardware_Info"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hardware_Quantity"));
         }
    }
    #endregion

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }
}
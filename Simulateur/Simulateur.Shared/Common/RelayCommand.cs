using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Simulateur.Common
{
	public class RelayCommand : ICommand
	{

		private readonly Action _methodToExecute;
		private readonly Func<bool> _canExecuteEvaluator;

		public event EventHandler CanExecuteChanged;


		public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
		{
			_methodToExecute = methodToExecute;
			_canExecuteEvaluator = canExecuteEvaluator;
		}
		public RelayCommand(Action methodToExecute)
			: this(methodToExecute, null)
		{
		}
		public bool CanExecute(object parameter)
		{
			if (_canExecuteEvaluator == null)
			{
				return true;
			}
			else
			{
				bool result = _canExecuteEvaluator.Invoke();
				return result;
			}
		}
		public void Execute(object parameter)
		{
			_methodToExecute.Invoke();
		}
	}


	public class RelayCommand<T> : ICommand
	{
		#region Fields

		private readonly Action<T> _execute = null;
		private readonly Predicate<T> _canExecute = null;

		public event EventHandler CanExecuteChanged;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new command that can always execute.
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		/// <summary>
		/// Creates a new command with conditional execution.
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

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute((T)parameter);
		}

		public void Execute(object parameter)
		{
			_execute((T)Convert.ChangeType(parameter, typeof(T)));
		}

		#endregion
	}
}

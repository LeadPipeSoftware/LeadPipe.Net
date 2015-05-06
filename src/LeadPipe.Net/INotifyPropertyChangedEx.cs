// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotifyPropertyChangedEx.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core
{
	using System.ComponentModel;

	/// <summary>
	/// Extends <see cref="INotifyPropertyChanged"/> such that the change event can be raised by external parties.
	/// </summary>
	public interface INotifyPropertyChangedEx : INotifyPropertyChanged
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets a value indicating whether this instance is notifying.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is notifying; otherwise, <c>false</c>.
		/// </value>
		bool IsNotifying { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Notifies subscribers of the property change.
		/// </summary>
		/// <param name="propertyName">
		/// Name of the property.
		/// </param>
		void NotifyOfPropertyChange(string propertyName);

		/// <summary>
		/// Raises a change notification indicating that all bindings should be refreshed.
		/// </summary>
		void Refresh();

		#endregion
	}
}
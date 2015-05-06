// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyPropertyChanged.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// A base class that implements the infrastructure for property change notification and automatically performs UI
	/// thread marshalling.
	/// </summary>
	[Serializable]
	public abstract class NotifyPropertyChanged : INotifyPropertyChangedEx, IChangeTracking
	{
		#region Constants and Fields

		/// <summary>
		/// Determines if the implementing type has changed.
		/// </summary>
		[field:
			SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
				Justification = "Suppression is OK here because we aren't really using Hungarian notation.")]
		[field: NonSerialized]
		private bool isChanged;

		/// <summary>
		/// Determines if the implementing type is notifying.
		/// </summary>
		[field:
			SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
				Justification = "Suppression is OK here because we aren't really using Hungarian notation.")]
		[field: NonSerialized]
		private bool isNotifying;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyPropertyChanged"/> class.
		/// </summary>
		protected NotifyPropertyChanged()
		{
			this.IsNotifying = true;
		}

		#endregion

		#region Public Events

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets a value indicating whether the object's has changed.
		/// </summary>
		/// <returns>
		/// true if the object’s content has changed since the last call to <see cref="M:System.ComponentModel.IChangeTracking.AcceptChanges"/>; otherwise, false.
		/// </returns>
		public bool IsChanged
		{
			get
			{
				return this.isChanged;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is notifying.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is notifying; otherwise, <c>false</c>.
		/// </value>
		public bool IsNotifying
		{
			get
			{
				return this.isNotifying;
			}

			set
			{
				this.isNotifying = value;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Resets the object’s state to unchanged by accepting the modifications.
		/// </summary>
		public void AcceptChanges()
		{
			this.isChanged = false;
		}

		/// <summary>
		/// Notifies subscribers of the property change.
		/// </summary>
		/// <param name="propertyName">
		/// Name of the property.
		/// </param>
		public virtual void NotifyOfPropertyChange(string propertyName)
		{
			if (this.IsNotifying)
			{
				this.RaisePropertyChangedEventCore(propertyName);
			}
		}

		/// <summary>
		/// Notifies subscribers of the property change.
		/// </summary>
		/// <typeparam name="TProperty">
		/// The type of the property.
		/// </typeparam>
		/// <param name="property">
		/// The property expression.
		/// </param>
		public virtual void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
		{
			this.NotifyOfPropertyChange(property.GetMemberInfo().Name);
		}

		/// <summary>
		/// Raises the property changed event immediately.
		/// </summary>
		/// <param name="propertyName">
		/// Name of the property.
		/// </param>
		public virtual void RaisePropertyChangedEventImmediately(string propertyName)
		{
			if (this.IsNotifying)
			{
				this.RaisePropertyChangedEventCore(propertyName);
			}
		}

		/// <summary>
		/// Raises a change notification indicating that all bindings should be refreshed.
		/// </summary>
		public void Refresh()
		{
			this.NotifyOfPropertyChange(string.Empty);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Called immediately after the deserialization of the implementing object.
		/// </summary>
		/// <param name="c">
		/// A description of the source and destination of a serialized stream.
		/// </param>
		[OnDeserialized]
		private void OnDeserialized(StreamingContext c)
		{
			this.IsNotifying = true;
		}

		/// <summary>
		/// The raise property changed event core.
		/// </summary>
		/// <param name="propertyName">
		/// The changed property name.
		/// </param>
		private void RaisePropertyChangedEventCore(string propertyName)
		{
			var handler = this.PropertyChanged;

			if (handler.IsNotNull())
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}

			this.isChanged = true;
		}

		#endregion
	}
}
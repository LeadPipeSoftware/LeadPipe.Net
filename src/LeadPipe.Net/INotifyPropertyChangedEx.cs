// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace LeadPipe.Net
{
    /// <summary>
    /// Extends <see cref="INotifyPropertyChanged"/> such that the change event can be raised by external parties.
    /// </summary>
    public interface INotifyPropertyChangedEx : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is notifying.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is notifying; otherwise, <c>false</c>.
        /// </value>
        bool IsNotifying { get; set; }

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
    }
}
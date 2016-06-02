// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net.CommonObjects.CommonObjects
{
    /// <summary>
    /// A simple representation of a U.S. postal address.
    /// </summary>
    public class Address
    {
        // Ref: http://pe.usps.gov/cpim/ftp/pubs/Pub28/pub28.pdf

        /// <summary>
        /// The attention line is placed above the Recipient Line, that is, above the name of the
        /// firm to which the mailpiece is directed.
        /// </summary>
        private string attentionLine;

        /// <summary>
        /// The delivery address line contains the primary and secondary address of the recipient.
        /// </summary>
        private string deliveryAddressLine;

        /// <summary>
        /// The last line contains the city, state, and ZIP(+4) code for the delivery address.
        /// </summary>
        private string lastLine;

        /// <summary>
        /// The recipient line contains the name of the firm to which the mailpiece is directed.
        /// </summary>
        private string recipientLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="attentionLine">The attention line.</param>
        /// <param name="recipientLine">The recipient line.</param>
        /// <param name="deliveryAddressLine">The delivery address line.</param>
        /// <param name="lastLine">The last line.</param>
        public Address(string attentionLine, string recipientLine, string deliveryAddressLine, string lastLine)
        {
            this.attentionLine = attentionLine;
            this.recipientLine = recipientLine;
            this.deliveryAddressLine = deliveryAddressLine;
            this.lastLine = lastLine;
        }

        protected Address()
        {
        }

        /// <summary>
        /// The attention line is placed above the Recipient Line, that is, above the name of the
        /// firm to which the mailpiece is directed.
        /// </summary>
        public virtual string AttentionLine
        {
            get { return attentionLine; }
        }

        /// <summary>
        /// The delivery address line contains the primary and secondary address of the recipient.
        /// </summary>
        public virtual string DeliveryAddressLine
        {
            get { return deliveryAddressLine; }
        }

        /// <summary>
        /// The last line contains the city, state, and ZIP(+4) code for the delivery address.
        /// </summary>
        public virtual string LastLine
        {
            get { return lastLine; }
        }

        /// <summary>
        /// The recipient line contains the name of the firm to which the mailpiece is directed.
        /// </summary>
        public virtual string RecipientLine
        {
            get { return recipientLine; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Concat(
                AttentionLine, Environment.NewLine,
                RecipientLine, Environment.NewLine,
                DeliveryAddressLine, Environment.NewLine,
                LastLine);
        }
    }
}
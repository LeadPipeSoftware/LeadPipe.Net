// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace LeadPipe.Net
{
    /// <summary>
    /// Extension methods for the Abbreviation attribute.
    /// </summary>
    public static class AbbreviationExtensions
    {
        /// <summary>
        /// Gets the abbreviation attribute value if it exists.
        /// </summary>
        /// <param name="value">The abbreviation value.</param>
        /// <returns>The abbreviation value.</returns>
        public static string GetAbbreviation(this Enum value)
        {
            var type = value.GetType();

            var name = Enum.GetName(type, value);

            if (name == null) return name;

            var field = type.GetField(name);

            if (field == null) return name;

            var attr = Attribute.GetCustomAttribute(field, typeof(Abbreviation)) as Abbreviation;

            return attr != null ? attr.Value : name;
        }
    }

    /// <summary>
    /// The Abbreviation attribute for properties, enum values, and fields. Allows for assigning abbreviations easily.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Abbreviation : Attribute
    {
        /// <summary>
        /// The value's Value.
        /// </summary>
        private readonly string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Abbreviation"/> class.
        /// </summary>
        public Abbreviation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Abbreviation"/> class.
        /// </summary>
        /// <param name="value">The abbreviation Value.</param>
        public Abbreviation(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the abbreviation Value.
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }
}
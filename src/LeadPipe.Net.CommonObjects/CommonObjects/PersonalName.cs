// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonalName.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Extensions;
using System.Collections.Generic;

namespace LeadPipe.Net.CommonObjects
{
    public enum PersonalNameLexicalConvention
    {
        /// <summary>
        /// The Western lexical convention (GIVEN FAMILY).
        /// </summary>
        Western = 0, l,

        /// <summary>
        /// The Eastern lexical convention (FAMILY GIVEN).
        /// </summary>
        Eastern = 1
    }

    /// <summary>
    /// A simple representation of a person's name.
    /// </summary>
    public class PersonalName
    {
        #region Private Properties

        /// <summary>
        /// The person's given name.
        /// </summary>
        private string givenName;

        /// <summary>
        /// The person's family name.
        /// </summary>
        private string familyName;

        /// <summary>
        /// The person's middle names.
        /// </summary>
        private List<string> middleNames;

        /// <summary>
        /// The person's name prefix.
        /// </summary>
        private string prefix;

        /// <summary>
        /// The person's name suffix.
        /// </summary>
        private string suffix;

        /// <summary>
        /// The lexical convention of the person's name.
        /// </summary>
        private PersonalNameLexicalConvention lexicalConvention;

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Gets the person's given name.
        /// </summary>
        /// <value>The person's given name.</value>
        public virtual string GivenName
        {
            get { return givenName; }
        }

        /// <summary>
        /// Gets the person's family name.
        /// </summary>
        /// <value>The person's family name.</value>
        public virtual string FamilyName
        {
            get { return this.familyName; }
        }

        /// <summary>
        /// Gets the person's full name.
        /// </summary>
        /// <value>The person's full name.</value>
        public virtual string FullName
        {
            get
            {
                var flattenedMiddleNames = middleNames.WrapEachWith(string.Empty, string.Empty, " ");

                return lexicalConvention.Equals(PersonalNameLexicalConvention.Western)
                    ? string.Concat(this.prefix, " ", this.givenName, " ", flattenedMiddleNames, " ", this.familyName, ", ", this.suffix)
                    : string.Concat(this.prefix, " ", this.familyName, " ", flattenedMiddleNames, " ", this.givenName, ", ", this.suffix);
            }
        }

        /// <summary>
        /// Gets the person's middle names.
        /// </summary>
        /// <value>The person's middle names.</value>
        public virtual IEnumerable<string> MiddleNames
        {
            get { return this.middleNames; }
        }

        /// <summary>
        /// Gets the lexical convention of the person's name.
        /// </summary>
        /// <value>The lexical convention of the person's name.</value>
        public virtual PersonalNameLexicalConvention LexicalConvention
        {
            get { return this.lexicalConvention; }
        }

        /// <summary>
        /// The person's name prefix.
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
        }

        /// <summary>
        /// The person's name suffix.
        /// </summary>
        public string Suffix
        {
            get { return suffix; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Adds a person's middle name.
        /// </summary>
        /// <param name="middleName">The person's middle name.</param>
        public virtual void AddMiddleName(string middleName)
        {
            this.middleNames.Add(middleName);
        }

        /// <summary>
        /// Deletes a person's middle name.
        /// </summary>
        /// <param name="middleName">The person's middle name.</param>
        public virtual void DeleteMiddleName(string middleName)
        {
            this.middleNames.Remove(middleName);
        }

        /// <summary>
        /// Deletes the person's name prefix.
        /// </summary>
        public virtual void DeletePrefix()
        {
            this.prefix = null;
        }

        /// <summary>
        /// Deletes the person's name suffix.
        /// </summary>
        public virtual void DeleteSuffix()
        {
            this.suffix = null;
        }

        /// <summary>
        /// Updates the person's given name.
        /// </summary>
        /// <param name="givenName">The person's given name.</param>
        public virtual void UpdateGivenName(string givenName)
        {
            this.givenName = givenName;
        }

        /// <summary>
        /// Updates the person's family name.
        /// </summary>
        /// <param name="familyName">The person's family name.</param>
        public virtual void UpdateFamilyName(string familyName)
        {
            this.familyName = familyName;
        }

        /// <summary>
        /// Updates the person's name suffix.
        /// </summary>
        /// <param name="suffix">The suffix.</param>
        public virtual void UpdateSuffix(string suffix)
        {
            this.suffix = suffix;
        }

        /// <summary>
        /// Updates the person's name prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        public virtual void UpdatePrefix(string prefix)
        {
            this.prefix = prefix;
        }

        /// <summary>
        /// Updates the lexical convention of the person's name.
        /// </summary>
        /// <param name="lexicalConvention">The lexical convention of the person's name.</param>
        public virtual void UpdateLexicalConvention(PersonalNameLexicalConvention lexicalConvention)
        {
            this.lexicalConvention = lexicalConvention;
        }

        /// <summary>
        /// Updates a person's middle name.
        /// </summary>
        /// <param name="oldMiddleName">The old middle name.</param>
        /// <param name="newMiddleName">The new middle name.</param>
        public virtual void UpdateMiddleName(string oldMiddleName, string newMiddleName)
        {
            var index = this.middleNames.IndexOf(oldMiddleName);

            if (index != -1)
            {
                this.middleNames.ReplaceItemAt(index, newMiddleName);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        #endregion Protected Methods
    }
}
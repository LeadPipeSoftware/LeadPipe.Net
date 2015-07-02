// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEncryptable.cs" company="Lead Pipe Software">
//     Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// An interface that defines an object that can be encrypted.
    /// </summary>
    public interface IEncryptable
    {
        /// <summary>
        /// Encrypts this instance.
        /// </summary>
        void Encrypt();

        /// <summary>
        /// Decrypts this instance.
        /// </summary>
        void Decrypt();
    }
}
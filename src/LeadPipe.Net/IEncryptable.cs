// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
    /// <summary>
    /// An interface that defines an object that can be encrypted.
    /// </summary>
    public interface IEncryptable
    {
        /// <summary>
        /// Decrypts this instance.
        /// </summary>
        void Decrypt();

        /// <summary>
        /// Encrypts this instance.
        /// </summary>
        void Encrypt();
    }
}
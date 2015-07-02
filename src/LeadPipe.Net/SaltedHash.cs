// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaltedHash.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace LeadPipe.Net
{
    /// <summary>
    /// Provides salted hash capabilities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Hash algorithms are one way functions that turn data into a fixed-length checksum that cannot be reversed. When
    /// designed and implemented properly, they are very sensitive meaning that if even a little tiny bit of the source
    /// data changes the resulting hash would be completely different. Hashes are just the ticket for storing sensitive
    /// data without *actually* storing it. Like this:
    /// </para>
    /// <para>
    /// 1. The user creates an account.
    /// 2. The user's password is hashed and the result stored in the database.
    /// 3. The user attempts to login, the password they supply is hashed, and then compared to the stored hash value.
    /// 4. If the hashes match, the user is granted access. If not, the user is rejected.
    /// 5. Steps 3 and 4 repeat every time someone tries to login to their account.
    /// </para>
    /// <para>
    /// Unfortunately, simply hashing passwords isn't enough to keep passwords secure. While hashing is FAR better than
    /// storing passwords in plain text (not hashed), there are a lot of ways to quickly recover passwords from normal
    /// hashes. Generally, user passwords can be cracked in 24 hours or less with modern tools and techniques such as
    /// lookup tables, dictionaries, rainbows, and so forth.
    /// </para>
    /// <para>
    /// The good news is that we can make cracking hashes MUCH more difficult. One of the quickest and easiest ways is
    /// to salt the hash. Salting is nothing more than appending a string of random characters to the data before the
    /// hash is calculated. Doing so makes lookup and rainbow tables useless.
    /// </para>
    /// <para>
    /// One thing you don't want to do is to use the same salt value for every hash. You also want to avoid using a
    /// salt value that is too short. In fact, it's generally recommended that the salt length be the same length as
    /// the output of the hash. For example, a 256 bit hash such as SHA256 would use a 256 bit salt value. You'll also
    /// want to use a randomly generated salt value generated with a cryptographically secure pseudo-random number
    /// generator. Oh, and don't forget to re-salt the hash if the user changes their password.
    /// </para>
    /// <para>
    /// Now that you're using salted hashes and, therefore, you've eliminated the lookup and rainbow attack vectors as
    /// plausible options, you can protect your users further by implementing key stretching techniques to make attacks
    /// such as brute force and dictionary attacks harder. If you're interested, check out PBKDF2.
    /// </para>
    /// </remarks>
    public class SaltedHash
    {
        #region Constants and Fields

        /// <summary>
        /// The hash provider.
        /// </summary>
        private readonly HashAlgorithm hashProvider;

        /// <summary>
        /// The salt length.
        /// </summary>
        private readonly int saltLength;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SaltedHash"/> class.
        /// </summary>
        /// <param name="hashAlgorithm">A <see cref="HashAlgorithm"/>The hash algorithm to use.</param>
        /// <param name="saltLength">The the salt length.</param>
        public SaltedHash(HashAlgorithm hashAlgorithm, int saltLength)
        {
            this.hashProvider = hashAlgorithm;
            this.saltLength = saltLength;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaltedHash"/> class (uses SHA256Managed and a 256 bit salt).
        /// </summary>
        public SaltedHash()
            : this(new SHA256Managed(), 32)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns both a hash and a salt for the supplied data.
        /// </summary>
        /// <param name="data">A <see cref="System.Byte"/>byte array containing the data from which to derive the salt.</param>
        /// <param name="hash">A <see cref="System.Byte"/>byte array which will contain the hash calculated.</param>
        /// <param name="salt">A <see cref="System.Byte"/>byte array which will contain the salt generated.</param>
        public void GetHashAndSalt(byte[] data, out byte[] hash, out byte[] salt)
        {
            // Allocate memory for the salt...
            salt = new byte[this.saltLength];

            // Strong runtime pseudo-random number generator, on Windows uses CryptAPI on Unix /dev/urandom...
            using (var random = new RNGCryptoServiceProvider())
            {
                // Create a random salt...
                random.GetNonZeroBytes(salt);
            }

            // Compute hash value of our data with the salt...
            hash = this.ComputeHash(data, salt);
        }

        /// <summary>
        /// Gets the hash and salt values as Base-64 encoded strings.
        /// </summary>
        /// <param name="data">
        /// A <see cref="System.String"/> string containing the data to hash.
        /// </param>
        /// <param name="hash">
        /// A <see cref="System.String"/> base64 encoded string containing the generated hash.
        /// </param>
        /// <param name="salt">
        /// A <see cref="System.String"/> base64 encoded string containing the generated salt.
        /// </param>
        public void GetHashAndSaltString(string data, out string hash, out string salt)
        {
            byte[] hashOut;
            byte[] saltOut;

            // Obtain the hash and salt for the given string...
            this.GetHashAndSalt(Encoding.UTF8.GetBytes(data), out hashOut, out saltOut);

            // Transform the byte[] to Base-64 encoded strings...
            hash = Convert.ToBase64String(hashOut);
            salt = Convert.ToBase64String(saltOut);
        }

        /// <summary>
        /// Verifies whether the data generates the same hash as we had stored previously.
        /// </summary>
        /// <param name="data">The data to verify .</param>
        /// <param name="hash">The hash we had stored previously.</param>
        /// <param name="salt">The salt we had stored previously.</param>
        /// <returns>
        /// True on a successful match.
        /// </returns>
        public bool VerifyHash(byte[] data, byte[] hash, byte[] salt)
        {
            var newHash = this.ComputeHash(data, salt);

            // Since there's no easy array comparison in C#, we'll do the legwork manually...
            if (newHash.Length != hash.Length)
            {
                return false;
            }

            for (var lp = 0; lp < hash.Length; lp++)
            {
                if (!hash[lp].Equals(newHash[lp]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifies whether the data generates the same hash as we had stored previously.
        /// </summary>
        /// <param name="data">A UTF-8 encoded string containing the data to verify.</param>
        /// <param name="hash">A base-64 encoded string containing the previously stored hash.</param>
        /// <param name="salt">A base-64 encoded string containing the previously stored salt.</param>
        /// <returns>
        /// True if the data matches a hash and salt.
        /// </returns>
        public bool VerifyHashString(string data, string hash, string salt)
        {
            var hashToVerify = Convert.FromBase64String(hash);
            var saltToVerify = Convert.FromBase64String(salt);
            var dataToVerify = Encoding.UTF8.GetBytes(data);

            return this.VerifyHash(dataToVerify, hashToVerify, saltToVerify);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Computes a salted hash.
        /// </summary>
        /// <param name="data">A byte array of the data to Hash.</param>
        /// <param name="salt">A byte array of the Salt to add to the Hash.</param>
        /// <returns>
        /// A byte array with the calculated hash.
        /// </returns>
        private byte[] ComputeHash(byte[] data, byte[] salt)
        {
            // Allocate memory to store both the data and salt together...
            var dataAndSalt = new byte[data.Length + this.saltLength];

            // Copy both the data and salt into the new array...
            Array.Copy(data, dataAndSalt, data.Length);
            Array.Copy(salt, 0, dataAndSalt, data.Length, this.saltLength);

            // Compute hash value of our plain text with appended salt...
            return this.hashProvider.ComputeHash(dataAndSalt);
        }

        #endregion
    }
}
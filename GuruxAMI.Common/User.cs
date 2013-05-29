//
// --------------------------------------------------------------------------
//  Gurux Ltd
// 
//
//
// Filename:        $HeadURL$
//
// Version:         $Revision$,
//                  $Date$
//                  $Author$
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License 
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// This code is licensed under the GNU General Public License v2. 
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------

using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using ServiceStack.OrmLite;
using System.Security.Cryptography;
using System.IO;

namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract class representing User object.
    /// User class is used to manage user authentication, authorization and general settings.
    /// </summary>
    [Serializable, Alias("User")]
	public class GXAmiUser : IHasId<long>
	{
        private static string md5(string text)
        {
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(new System.Text.ASCIIEncoding().GetBytes(text))).Replace("-", "").ToLower();
        }

        static public string GetCryptedPassword(string name, string password)
        {
            // form the string for encrypting
            // and put into byte array
            string textToEncrypt = name + md5(password);
            byte[] plainTextBytes = new System.Text.ASCIIEncoding().GetBytes(textToEncrypt);

            // set up encrytion object
            RijndaelManaged aes128 = new RijndaelManaged();
            aes128.KeySize = 128;
            aes128.BlockSize = 128;
            aes128.Padding = PaddingMode.PKCS7;
            aes128.Mode = CipherMode.CBC;
            byte[] key = new byte[16];
            Array.Copy(new System.Text.ASCIIEncoding().GetBytes(textToEncrypt), key, 16);
            aes128.Key = key;
            //aes128.IV = new byte[] { 0x67, 0x40, 0x38, 0x2b, 0x47, 0x5e, 0x13, 0x49, 0x7b, 0x56, 0x34, 0x78, 0x31, 0x54, 0x5a, 0x65 };
            aes128.IV = System.Text.ASCIIEncoding.ASCII.GetBytes("GuruxSoftwareLtd");
            // encrypt the data            
            ICryptoTransform encryptor = aes128.CreateEncryptor();
            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            cs.Write(plainTextBytes, 0, plainTextBytes.Length);

            // convert our encrypted data from a memory stream into a byte array.
            cs.FlushFinalBlock();

            byte[] cypherTextBytes = ms.ToArray();

            // close memory stream
            ms.Close();
            return System.Uri.EscapeDataString(Convert.ToBase64String(cypherTextBytes));
        }     

        /// <summary>
        /// The database ID of the user
        /// </summary>
        [DataMember()]
		[Alias("ID"), AutoIncrement, Index(Unique = true)]
        public long Id
		{
			get;
			set;
		}

        /// <summary>
        /// The name of the user
        /// </summary>
        [DataMember(), Index(Unique = false)]
        public string Name
		{
			get;
			set;
		}

        /// <summary>
        /// The password of the user (encrypted)
        /// </summary>
        [DataMember()]
		public string Password
		{
			get;
			set;
		}

        /// <summary>
        /// Update password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pw"></param>
        void SetCryptedPassword(string userName, string pw)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Invalid name.");
            }
            if (string.IsNullOrEmpty(pw))
            {
                throw new ArgumentException("Invalid Password.");
            }
            this.Password = GXAmiUser.GetCryptedPassword(userName, pw);
        }        

        /// <summary>
        /// The real name of the user
        /// </summary>
        [DataMember()]
        public string RealName
		{
			get;
			set;
		}

        /// <summary>
        /// The description of the user
        /// </summary>        
        [DataMember()]
        public string Description
		{
			get;
			set;
		}

        /// <summary>
        /// The e-mail address of the user
        /// </summary>
        [DataMember()]
        public string Email
		{
			get;
			set;
		}

        /// <summary>
        /// The phone number of the user
        /// </summary>
        [DataMember()]
        public string PhoneNumber
		{
			get;
			set;
		}

        /// <summary>
        /// Access rights of the user
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public UserAccessRights AccessRights
		{
            get;
            set;
		}

        /// <summary>
        /// Returns UserAccessRights enum valus as integer.
        /// </summary>
        [Alias("AccessRights")]
        [DataMember()]
        public int AccessRightsAsInt
        {
            get
            {
                return (int) AccessRights;
            }
            set
            {
                AccessRights = (UserAccessRights) value;
            }
        }        

        /// <summary>
        /// Date and time when the user was created
        /// </summary>      
        [DataMember()]
        public DateTime Added
		{
			get;
			set;
		}

        /// <summary>
        /// If this is not null then the user is removed and should not be displayed on the user interface
        /// </summary>
        [DataMember()]
        public DateTime? Removed
		{
			get;
			set;
		}

        /// <summary>
        /// If the user has a limit of maximum devices
        /// </summary>
        [DataMember()]
        public int DeviceLimit
		{
			get;
			set;
		}
        /// <summary>
        /// Constructor.
        /// </summary>
		public GXAmiUser()
		{
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <param name="pw">Password.</param>
        /// <param name="access">User accessrights.</param>
		public GXAmiUser(string name, string pw, UserAccessRights access)
		{
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid name.");
            }
            if (string.IsNullOrEmpty(pw))
            {
                throw new ArgumentException("Invalid Password.");
            }
			this.Name = name;
			this.Password = GXAmiUser.GetCryptedPassword(name, pw);
            AccessRights = access;
		}
	}
}

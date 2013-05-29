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
using Gurux.Device.Editor;
using ServiceStack.OrmLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuruxAMI.Common
{
    [Serializable, Alias("Parameter")]
    public class GXAmiParameter : IHasId<ulong>
	{
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        [DataMember, Index(Unique = false)]
        public ulong ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// Device template ID.
        /// </summary>
        [DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
        public virtual ulong DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// Property template ID.
        /// </summary>
        [DataMember]
        public virtual ulong TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// parameter template Version.
        /// </summary>        
        [DataMember]
        public int TemplateVersion
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }
        [DataMember]
        public object Value
        {
            get;
            set;
        }
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Type is saves as a string to DB. Use Type instead.
        /// </summary>
        [Alias("Type")]
        [DataMember(), StringLength(100)]
        public string TypeAsString
        {
            get;
            set;
        }

        Type m_Type;

        [ServiceStack.DataAnnotations.Ignore]
        [System.Runtime.Serialization.IgnoreDataMember()]
        public Type Type
        {
            get
            {
                if (m_Type != null)
                {
                    return m_Type;
                }
                if (string.IsNullOrEmpty(TypeAsString))
                {
                    return null;
                }
                m_Type = Type.GetType(TypeAsString);
                return m_Type;
            }
            set
            {
                m_Type = value;
                if (value != null)
                {
                    TypeAsString = value.FullName;
                }
                else
                {
                    TypeAsString = null;
                }
            }
        }

        [DataMember]
        public bool Storable
        {
            get;
            set;
        }

        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public ValueAccessType Access
        {
            get;
            set;
        }

        /// <summary>
        /// Returns parameter access type enum valus as integer.
        /// </summary>
        [Alias("Access")]
        [DataMember()]
        public int AccessAsInt
        {
            get
            {
                return (int)Access;
            }
            set
            {
                Access = (ValueAccessType)value;
            }
        }

        public GXAmiParameter Clone()
        {
            GXAmiParameter p = new GXAmiParameter();
            p.Id = Id;
            p.ParentID = ParentID;
            p.DeviceID = DeviceID;
            p.TemplateId = TemplateId;
            p.TemplateVersion = TemplateVersion;
            p.Value = Value;
            p.Description = Description;
            p.TypeAsString = TypeAsString;
            p.Storable = Storable;
            p.Access = Access;
            return p;
        }
	}
}

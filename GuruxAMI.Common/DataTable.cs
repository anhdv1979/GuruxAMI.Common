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
using System;
using System.Runtime.Serialization;
using ServiceStack.OrmLite;
using System.ComponentModel.DataAnnotations;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{    
    [Serializable, Alias("DataTable")]
    public class GXAmiDataTable
    {
        [Alias("ID"), DataMember, Index()]		
        public virtual ulong Id
		{
            get
            {
                return DeviceID | TemplateId;
            }
            set
            {
                //Ignore set.
            }
		}

        /// <summary>
        /// Device ID.
        /// </summary>        
        [DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
        public virtual ulong DeviceID
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Category template ID.
        /// </summary>
        [DataMember]
        public virtual ulong TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// Table template Version.
        /// </summary>        
        [DataMember]
        public int TemplateVersion
        {
            get;
            set;
        }
		
        [DataMember]
        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiParameter[] Parameters
		{
			get;
			set;
		}

        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public Gurux.Device.DisabledActions DisabledActions
        {
            get;
            set;
        }

        /// <summary>
        /// Returns Disabled Actions enum valus as integer.
        /// </summary>
        [Alias("DisabledActions")]
        [DataMember()]
        public int DisabledActionsAsInt
        {
            get
            {
                return (int)DisabledActions;
            }
            set
            {
                DisabledActions = (Gurux.Device.DisabledActions)value;
            }
        }

        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiVisualizer Visualizer
        {
            get;
            set;
        }

        /// <summary>
        /// Property IDs
        /// </summary>
        [DataMember, ServiceStack.DataAnnotations.Ignore]
        public GXAmiProperty[] Columns
        {
            get;
            set;
        }

        [DataMember, ServiceStack.DataAnnotations.Ignore]
        public GXAmiDataRow[] Rows
        {
            get;
            set;
        }
    }    
}

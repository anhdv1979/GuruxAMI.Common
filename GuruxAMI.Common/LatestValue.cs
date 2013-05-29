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
using ServiceStack.DesignPatterns.Model;
using ServiceStack.OrmLite;
using System.ComponentModel.DataAnnotations;
namespace GuruxAMI.Common
{    
    [Serializable, Alias("TableTemplate")]
    public class GXAmiTableTemplate : GXAmiDataTable
    {
        [Alias("ID"), DataMember]
        public override ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Device ID.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public override ulong DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// Hide Table template ID.
        /// </summary>
        [Ignore]
        public override ulong TemplateId
        {
            get;
            set;
        }

        public GXAmiDataTable ToTable()
        {
            GXAmiDataTable table = new GXAmiDataTable();
            table.TemplateVersion = TemplateVersion;
            table.TemplateId = Id & 0xFFFF;
            table.Name = Name;            
            table.DisabledActions = DisabledActions;
            return table;
        }
    }

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

    [Serializable, Alias("DataRow")]
    public class GXAmiDataRow : GXAmiDataValue
    {
        [Alias("ID"), DataMember, AutoIncrement(), Index()]
        public virtual ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// In what table this property belongs.
        /// </summary>        
        [DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiDataTable), OnDelete = "CASCADE")]
        public virtual ulong TableID
        {
            get;
            set;
        }

        /// <summary>
        /// Column Index.
        /// </summary>
        [DataMember]
        public uint ColumnIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Row index.
        /// </summary>
        [DataMember, Index(Unique = false)]
        public uint RowIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataRow()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataRow(ulong tableID, ulong propertyID, string value, uint rowIndex, uint columnIndex)
        {
            TableID = tableID;
            RowIndex = rowIndex;
            PropertyID = propertyID;
            UIValue = value;
            ColumnIndex = columnIndex;
        }

    }

    [Serializable, Alias("DataValue")]
    public class GXAmiDataValue
    {
        /// <summary>
        /// Property ID is unique in latest value.
        /// </summary>
        [DataMember]
        public virtual ulong PropertyID
        {
            get;
            set;
        }


        [DataMember]
        public object UIValue
        {
            get;
            set;
        }
        
        [DataMember]
        public DateTime TimeStamp
        {
            get;
            set;
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue(ulong propertyID, string value)
        {
            PropertyID = propertyID;
            UIValue = value; 
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue(ulong propertyID, string value, DateTime timeStamp)
        {
            TimeStamp = timeStamp;
            PropertyID = propertyID;
            UIValue = value;
        }
    }

    /// <summary>
    /// Latest value is saved to the separet table to make queries faster.
    /// </summary>
    [Serializable, Alias("LatestValue")]
    public class GXAmiLatestValue : GXAmiDataValue, IHasId<ulong>	
	{
        /// <summary>
        /// Id is Property ID.
        /// </summary>
        [DataMember, Index()]
        public virtual ulong Id
        {
            get
            {
                return PropertyID;
            }
            set
            {
                PropertyID = value;
            }
        }

        [DataMember, Index(Unique = false)]
        [ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
		public ulong DeviceID
		{
			get;
			set;
		}
    }
}

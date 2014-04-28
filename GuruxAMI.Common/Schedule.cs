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
using System.Collections.Generic;
using System.Runtime.Serialization;
using Gurux.Device;
#if !SS4
using ServiceStack.DesignPatterns.Model;
using ServiceStack.OrmLite;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [Serializable, Alias("Schedule")]
	public class GXAmiSchedule : IHasId<ulong>
	{
        [Alias("ID"), AutoIncrement, DataMember]
		public ulong Id
		{
			get;
			set;
		}

        /// <summary>
        /// Name of schedule.
        /// </summary>
		[DataMember]
		public string Name
		{
			get;
			set;
		}
		
        /// <summary>
        /// Schedule description.
        /// </summary>
        [DataMember]
		public string Description
		{
			get;
			set;
		}

        ///<summary>
        ///DayOfWeek is used when RepeatMode is weekly. Determines weekday(s), when
        ///transaction is executed.
        ///</summary>
        ///<remarks>
        ///Multiple days can be specified.
        ///</remarks>        
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public System.DayOfWeek[] DayOfWeeks
        {
            get;
            set;
        }

        /// <summary>
        /// Returns AutoConnect enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("DayOfWeeks")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public int DayOfWeeksAsInt
        {
            get
            {
                int value = 0;
                if (DayOfWeeks != null)
                {
                    foreach (System.DayOfWeek it in DayOfWeeks)
                    {
                        value |= (1 << ((int)it));
                    }
                }
                return value;
            }
            set
            {
                List<System.DayOfWeek> list = new List<DayOfWeek>();
                int tmp;
                for (int pos = 0; pos != 7; ++pos)
                {
                    tmp = value & (1 << pos);
                    if (tmp != 0)
                    {
                        list.Add((DayOfWeek) pos);
                    }
                }
                DayOfWeeks = list.ToArray();
            }
        }

        ///<summary>
        ///TransactionCount determines how many times transaction is made, before stopping the current run.
        ///</summary>
        public int TransactionCount
        {
            get;
            set;
        }

        ///<summary>
        ///UpdateInterval is the execution interval of the transaction in seconds.
        ///</summary>        
        public int UpdateInterval
        {
            get;
            set;
        }

        /// <summary>
        /// Action to execute.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public ScheduleAction Action
		{
			get;
			set;
		}

        /// <summary>
        /// Returns Action enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("Action")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual int ActionAsInt
        {
            get
            {
                return (int)Action;
            }
            set
            {
                Action = (ScheduleAction)value;
            }
        }

		[DataMember]
		public int Interval
		{
			get;
			set;
		}

        ///<summary>
        ///How often schedule is executed.
        ///</summary>        
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public ScheduleRepeat RepeatMode
        {
            get;
            set;
        }

        /// <summary>
        /// Returns RepeatMode enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("RepeatMode")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual int AutoConnectAsInt
        {
            get
            {
                return (int)RepeatMode;
            }
            set
            {
                RepeatMode = (ScheduleRepeat)value;
            }
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? TransactionStartTime
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? TransactionEndTime
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? ScheduleStartTime
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? ScheduleEndTime
		{
			get;
			set;
		}

        /// <summary>
        /// When schedule is executed next time.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime? NextRunTine
        {
            get;
            set;
        }

        ///<summary>
        ///When schedule was last executed.
        ///</summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime? LastRunTime
        {
            get;
            set;
        }

        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public DayOfWeek DayOfWeek
		{
			get;
			set;
		}

        /// <summary>
        /// Returns DayOfWeek enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("DayOfWeek")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual int DayOfWeekAsInt
        {
            get
            {
                return (int)DayOfWeek;
            }
            set
            {
                DayOfWeek = (DayOfWeek)value;
            }
        }

		[DataMember]
		public int DayOfMonth
		{
			get;
			set;
		}
        
        /// <summary>
        /// When schedule item was added.
        /// </summary>
		[DataMember]
		public DateTime Added
		{
			get;
			set;
		}

        /// <summary>
        /// When schedule item is removed.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? Removed
		{
			get;
			set;
		}

        /// <summary>
        /// Schedule targets.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ServiceStack.DataAnnotations.Ignore]
		public GXAmiScheduleTarget[] Targets
		{
			get;
			set;
		}

        ///<summary>
        ///Status is the current state of the schedule item.
        ///</summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public ScheduleState Status
        {
            get;
            set;
        }

        /// <summary>
        /// Returns status enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("Status")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual int StatusAsInt
        {
            get
            {
                return (int)Status;
            }
            set
            {
                Status = (ScheduleState)value;
            }
        }

        /// <summary>
        /// Data collector ID where schedule is executed in or null if schedule is executed in 
        /// GuruxAMI server.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDataCollector), OnDelete = "CASCADE")]
        public ulong? TargetDC
        {
            get;
            set;
        }        

        ///<summary>
        ///FailWaitTime determines for how long a time (in ms) is waited before devices
        ///are tried to read again if failed.
        ///</summary>        
        public int FailWaitTime
        {
            get;
            set;
        }

        ///<summary>
        /// FailTryCount determines how many times devices are tried to read again if
        ///failed.
        ///</summary>
        public int FailTryCount
        {
            get;
            set;
        }

        ///<summary>
        /// ConnectionDelayTime determines for how long a time (in ms) is waited, before next connection is made.
        ///</summary>        
        public int ConnectionDelayTime
        {
            get;
            set;
        }

        ///<summary>
        /// MaxThreadCount is the maximum number of worker threads per Schedule item.
        ///</summary>        
        public int MaxThreadCount
        {
            get;
            set;
        }

        ///<summary>
        /// ConnectionFailWaitTime determines for how long a time (in ms) is waited,
        /// before next connection is made.
        ///</summary>
        public int ConnectionFailWaitTime
        {
            get;
            set;
        }

        ///<summary>
        /// How many times failed connection is tried to reconnect.
        ///</summary>
        public int ConnectionFailTryCount
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
		public GXAmiSchedule()
		{
			this.Action = ScheduleAction.Read;
            TransactionCount = 1;
			this.Interval = 1;
			this.TransactionStartTime = null;
            this.TransactionEndTime = null;
            this.RepeatMode = ScheduleRepeat.Once;
			this.DayOfWeek = DayOfWeek.Sunday;
			this.DayOfMonth = 1;
            this.ScheduleStartTime = null;
            this.ScheduleEndTime = null;
			this.Targets = null;
		}       
	}
}

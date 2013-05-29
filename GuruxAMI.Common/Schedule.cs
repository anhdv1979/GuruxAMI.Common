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
using System.Collections.Generic;
using System.Runtime.Serialization;
using Gurux.Device;

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

		[DataMember]
		public string Name
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

        ///<summary>
        ///DayOfWeek is used when RepeatMode is weekly. Determines weekday(s), when
        ///transaction is executed.
        ///</summary>
        ///<remarks>
        ///Multiple days can be specified.
        ///</remarks>        
        public System.DayOfWeek[] DayOfWeeks
        {
            get;
            set;
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

		[DataMember]
		public ScheduleAction Action
		{
			get;
			set;
		}

		[DataMember]
        public ScheduleRepeat Repeat
		{
			get;
			set;
		}

		[DataMember]
		public int Interval
		{
			get;
			set;
		}

        ///<summary>
        ///RepeatMode determines the repeat mode of a GXSchedule.
        ///</summary>        
        public ScheduleRepeat RepeatMode
        {
            get;
            set;
        }   

		[DataMember]
		public DateTime TransactionStartTime
		{
			get;
			set;
		}

		[DataMember]
		public DateTime TransactionEndTime
		{
			get;
			set;
		}

		[DataMember]
		public DateTime ScheduleStartTime
		{
			get;
			set;
		}

		[DataMember]
		public DateTime ScheduleEndTime
		{
			get;
			set;
		}

		[DataMember]
		public DayOfWeek DayOfWeek
		{
			get;
			set;
		}

		[DataMember]
		public int DayOfMonth
		{
			get;
			set;
		}

		[DataMember]
        public ScheduleState State
		{
			get;
			set;
		}

		[DataMember]
		public DateTime StateTimeStamp
		{
			get;
			set;
		}
		
		[DataMember]
		public DateTime Added
		{
			get;
			set;
		}

		[DataMember]
		public DateTime? Removed
		{
			get;
			set;
		}        

		[DataMember]
		public List<GXAmiScheduleTarget> Targets
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
			this.Interval = 1;
			this.TransactionStartTime = DateTime.MinValue;
			this.TransactionEndTime = DateTime.MaxValue;
            this.Repeat = ScheduleRepeat.Once;
			this.DayOfWeek = DayOfWeek.Sunday;
			this.DayOfMonth = 1;
			this.ScheduleStartTime = DateTime.MinValue;
            this.ScheduleEndTime = DateTime.MaxValue;
			this.Targets = new List<GXAmiScheduleTarget>();
		}

        /// <summary>
        /// Get schedule expiration time.
        /// </summary>
        /// <returns></returns>
		public DateTime? GetScheduleExpirationTime()
		{
			DateTime? expirationTime = null;
			if (this.Repeat == ScheduleRepeat.Day || this.Repeat == ScheduleRepeat.Week || this.Repeat == ScheduleRepeat.Month)
			{
				expirationTime = new DateTime?(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
				expirationTime = new DateTime?(expirationTime.Value.AddHours((double)this.TransactionEndTime.Hour));
				expirationTime = new DateTime?(expirationTime.Value.AddMinutes((double)this.TransactionEndTime.Minute));
				expirationTime = new DateTime?(expirationTime.Value.AddSeconds((double)this.TransactionEndTime.Second));
				if (this.TransactionStartTime > this.TransactionEndTime)
				{
					expirationTime = new DateTime?(expirationTime.Value.AddDays(1.0));
				}
			}
			return expirationTime;
		}
	}
}

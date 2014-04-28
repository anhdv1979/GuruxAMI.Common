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
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract class representing Task object
    /// Tasks are used for delivering commands to Data Collectors and Schedule Service.
    /// For example when a "Read Device"-button is pressed at UI a task is added to task list.
    /// An eligble Data Collector then proceeds to claim and excute the task.
    /// </summary>
    [DataContract()]
    [Serializable, Alias("Task")]
	public class GXAmiTask : IHasId<ulong>
	{
        /// <summary>
        /// The database ID of the task
        /// </summary>
        [Alias("ID"), DataMember, AutoIncrement, Index(Unique = true)]        
        public virtual ulong Id
		{
			get;
			set;
		}

        /// <summary>
        /// ReplyID is used if task is reply for a sent task.
        /// </summary>
        [Alias("ReplyID"), DataMember]
        public virtual ulong ReplyId
        {
            get;
            set;
        }

        /// <summary>
        /// Task data.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string Data
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the task
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public TaskType TaskType
		{
			get;
			set;
		}

        /// <summary>
        /// Returns TaskType enum valus as integer.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [Alias("TaskType")]
        public int TaskTypeAsInt
        {
            get
            {
                return (int)TaskType;
            }
            set
            {
                TaskType = (TaskType)value;
            }
        }

        /// <summary>
        /// Task priority
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int Priority
		{
			get;
			set;
		}

        /// <summary>
        /// The type of the target
        /// </summary>		
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public TargetType TargetType
		{
			get;
			set;
		}

        /// <summary>
        /// Returns TargetType enum valus as integer.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [Alias("TargetType")]
        public int TargetTypeAsInt
        {
            get
            {
                return (int)TargetType;
            }
            set
            {
                TargetType = (TargetType)value;
            }
        }

        /// <summary>
        /// The database ID of the target
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public ulong TargetID
		{
			get;
			set;
		}

        /// <summary>
        /// Task sender as string.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, DataMember]
        public string SenderAsString
        {
            get;
            set;
        }

        /// <summary>
        /// Task target as string.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, DataMember]
        public string TargetAsString
        {
            get;
            set;
        }

        /// <summary>
        /// The database ID of the device containing the target.
        /// </summary>		
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
        public ulong? TargetDeviceID
		{
			get;
			set;
		}

        /// <summary>
        /// The database ID of the user issuing the task.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public long UserID
		{
			get;
			set;
		}

        /// <summary>
        /// The Guid of the sender data collector.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public Guid SenderDataCollectorGuid
        {
            get;
            set;
        }

        /// <summary>
        /// The Guid of the client listener.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public Guid Instance
        {
            get;
            set;
        }

        /// <summary>
        /// The state of the task
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public TaskState State
		{
			get;
			set;
		}

        /// <summary>
        /// Returns State enum valus as integer.
        /// </summary>
        [Alias("State")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public int StateAsInt
        {
            get
            {
                return (int)State;
            }
            set
            {
                State = (TaskState)value;
            }
        }

        /// <summary>
        /// The database ID of a DC that has claimed the task.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public ulong DataCollectorID
		{
			get;
			set;
		}

        /// <summary>
        /// Target DC guid.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public Guid DataCollectorGuid
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the task was created
        /// </summary>
        [Index(Unique = false)]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime CreationTime
		{
			get;
			set;
		}

        /// <summary>
        /// The time when a data collector has claimed the task. Null if that hasn't happened yet.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? ClaimTime
		{
			get;
			set;
		}

        /// <summary>
        /// The time when the task expires.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? ExpirationTime
		{
			get;
			set;
		}

        public override string ToString()
        {
            return Id.ToString() + " " + TaskType.ToString();
        }

        public GXAmiTask(Guid instance, TaskType taskType, Guid guid, string data)
        {
            Instance = instance;
            TargetType = TargetType.DataCollector;
            this.TaskType = taskType;
            Data = data;
            if (taskType == TaskType.MediaGetProperty ||
                taskType == TaskType.MediaSetProperty || 
                taskType == TaskType.MediaOpen || 
                taskType == TaskType.MediaClose ||
                taskType == TaskType.MediaWrite ||
                taskType == TaskType.MediaError ||
                taskType == TaskType.MediaState)
            {
                TargetType = TargetType.Media;
                DataCollectorGuid = guid;
                return;
            }
            throw new Exception("Invalid target");
        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        public GXAmiTask(Guid instance, TaskType taskType, object target)
		{
            Instance = instance;
			this.TaskType = taskType;
            ulong mask = 0xFFFF;
            if (target is GXAmiDeviceGroup)
            {
                this.TargetType = TargetType.DeviceGroup;
                this.TargetID = (target as GXAmiDeviceGroup).Id;
            }
            else if (target is GXAmiDevice)
            {
                this.TargetType = TargetType.Device;
                this.TargetDeviceID = this.TargetID = (target as GXAmiDevice).Id;                
            }
            else if (target is GXAmiCategory)
            {
                this.TargetType = TargetType.Category;
                this.TargetID = (ulong) (target as GXAmiCategoryTemplate).Id;                
                this.TargetDeviceID = (this.TargetID & ~mask);
            }
            else if (target is GXAmiDataTable)
            {
                this.TargetType = TargetType.Table;
                this.TargetID = (ulong)(target as GXAmiDataTable).Id;
                this.TargetDeviceID = (this.TargetID & ~mask);
            }
            else if (target is GXAmiPropertyTemplate)
            {
                this.TargetType = TargetType.Property;
                this.TargetID = (ulong)(target as GXAmiPropertyTemplate).Id;
                this.TargetDeviceID = (this.TargetID & ~mask);
            }
            else if (target is GXAmiSchedule)
            {
                this.TargetType = TargetType.Schedule;
                this.TargetID = (ulong)(target as GXAmiSchedule).Id;
            }            
            if (this.TargetID == 0 || this.TargetType == TargetType.None)
            {
                throw new Exception("Invalid target");
            }
		}

        /// <summary>
        /// Default constructor
        /// </summary>
		public GXAmiTask()
		{
		}

        /// <summary>
        /// Clone task.
        /// </summary>
        /// <returns></returns>
        public GXAmiTask Clone()
        {
            GXAmiTask task = new GXAmiTask();
            task.Instance = Instance; 
            task.Data = Data;
            task.TaskType = TaskType;
            task.Priority = Priority;
            task.TargetType = TargetType;
            task.TargetID = TargetID;
            task.TargetDeviceID = TargetDeviceID;
            task.UserID = UserID;
            task.SenderDataCollectorGuid = SenderDataCollectorGuid;
            task.State = State;
            task.DataCollectorID = DataCollectorID;
            task.DataCollectorGuid = DataCollectorGuid;
            task.CreationTime = CreationTime;
            task.ClaimTime = ClaimTime;
            task.ExpirationTime = ExpirationTime;
            return task;
        }
	}
}

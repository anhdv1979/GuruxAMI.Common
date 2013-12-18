using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System.Runtime.Serialization;
using ServiceStack.DesignPatterns.Model;

namespace GuruxAMI.Common
{
    [Serializable, Alias("DeviceTemplateDataBlock")]
    public class GXAmiDeviceTemplateDataBlock : IHasId<ulong>
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        [DataMember]
        [ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public ulong DeviceTemplateId
        {
            get;
            set;
        }

        [DataMember]
        public int Index
        {
            get;
            set;
        }

        [DataMember]
        public byte[] Data
        {
            get;
            set;
        }

        public GXAmiDeviceTemplateDataBlock()
        {
        }

        public GXAmiDeviceTemplateDataBlock(ulong templateId, int index, byte[] data, int length)
        {
            DeviceTemplateId = templateId;
            Index = index;
            Data = new byte[length];
            Array.Copy(data, Data, length);
        }
    }
}

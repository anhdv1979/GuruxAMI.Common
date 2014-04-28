using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System.Runtime.Serialization;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [Serializable, Alias("DeviceProfilesDataBlock")]
    public class GXAmiDeviceProfilesDataBlock : IHasId<ulong>
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        [DataMember]
        [ForeignKey(typeof(GXAmiDeviceProfile), OnDelete = "CASCADE")]
        public ulong DeviceProfilesId
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

        public GXAmiDeviceProfilesDataBlock()
        {
        }

        public GXAmiDeviceProfilesDataBlock(ulong profileId, int index, byte[] data, int length)
        {
            DeviceProfilesId = profileId;
            Index = index;
            Data = new byte[length];
            Array.Copy(data, Data, length);
        }
    }
}

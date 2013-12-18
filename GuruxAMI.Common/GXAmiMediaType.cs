using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using System.Runtime.Serialization;

namespace GuruxAMI.Common
{
    [Serializable, Alias("MediaType")]
    public class GXAmiMediaType
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Media name.
        /// </summary>
        public string Name
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

        /// <summary>
        /// Default media settings.
        /// </summary>
        public string Settings
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

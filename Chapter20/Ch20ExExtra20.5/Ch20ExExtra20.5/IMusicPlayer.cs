using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ch20ExExtra20._5
{
    [ServiceContract]
    internal interface IMusicPlayer
    {
        [OperationContract(IsOneWay =true)]
        void Play();
        [OperationContract(IsOneWay =true)]
        void Stop();
        [OperationContract]
        TrackInformation GetTrackingInformation();
    }

    [DataContract]
    internal class TrackInformation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TrackingData { get; set; }

    }
}

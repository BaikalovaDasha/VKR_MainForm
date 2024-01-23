using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADAHandler.Object
{
    public class Addresses
    {
        // поставить аттрибуты в таком формате [JsonProperty("access_token")]
        public Auth auth { get; set; }
        public Apis apis { get; set; }
    }

    public class Auth
    {
        public string tokenEndpointBasic { get; set; }
        public string tokenEndpointEmbedded { get; set; }
    }

    public class Apis
    {
        public Core core { get; set; }
        public OperationalTags operationaltags { get; set; }
        public Switches switches { get; set; }
        public OperationalJournal operationaljournal { get; set; }
        public MeasurementValue measurementvalues { get; set; }
        public RtEvents rtevents { get; set; }
        public Topology topology { get; set; }
        public ObjectModels objectmodels { get; set; }
        public ShiftPersonnel shiftpersonnel { get; set; }
        public IndirectMeasurementLinks indirectmeasurementlinks { get; set; }
        public VoltageViolations voltageviolations { get; set; }
        public RemoteOrganizations remoteorganizations { get; set; }
    }

    public class Core
    {
        public string baseAddressTemplate { get; set; }
    }

    public class OperationalTags
    {
        public string baseAddressTemplate { get; set; }
    }

    public class Switches
    {
        public string baseAddressTemplate { get; set; }
    }

    public class OperationalJournal
    {
        public string baseAddressTemplate { get; set; }
    }

    public class MeasurementValue
    {
        public string baseAddressTemplate { get; set; }
    }

    public class RtEvents
    {
        public string baseAddressTemplate { get; set; }
    }

    public class Topology
    {
        public string baseAddressTemplate { get; set; }
    }

    public class ObjectModels
    {
        public string baseAddressTemplate { get; set; }
    }

    public class ShiftPersonnel
    {
        public string baseAddressTemplate { get; set; }
    }

    public class IndirectMeasurementLinks
    {
        public string baseAddressTemplate { get; set; }
    }

    public class VoltageViolations
    {
        public string baseAddressTemplate { get; set; }
    }

    public class RemoteOrganizations
    {
        public string baseAddressTemplate { get; set; }
    }
}

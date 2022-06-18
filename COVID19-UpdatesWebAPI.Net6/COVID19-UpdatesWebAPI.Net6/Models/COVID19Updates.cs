using System.ComponentModel.DataAnnotations;

namespace COVID19_UpdatesWebAPI.Net6
{
    public class COVID19Updates
    {
        public string? FIPS { get; set; }
        public string? Admin2 { get; set; }
        public string? Province_State { get; set; }
        public string? Country_Region { get; set; }
        public string? Last_Update { get; set; }
        public string? Lat { get; set; }
        public string? Long_ { get; set; }
        public string? Confirmed { get; set; }
        public string? Deaths { get; set; }
        public string? Recovered { get; set; }
        public string? Active { get; set; }
        public string? Combined_Key { get; set; }
        public string? Incident_Rate { get; set; }
        public string? Case_Fatality_Ratio { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }

    public class COVID19UpdatesVM
    {
        public string? Province_State { get; set; }
        public string? Country_Region { get; set; }
        public string? Confirmed { get; set; }
        public string? Deaths { get; set; }
        public string? Recovered { get; set; }
        public string? Active { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdatedDate { get; set; }
    }

}

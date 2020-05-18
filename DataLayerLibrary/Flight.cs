using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayerLibrary
{
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }        
        public string FlightCode { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime FlightDate { get; set; }
        public string FromAirportFullname { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportFullname { get; set; }
        public string ToAirportIATA { get; set; }
        public string AircraftModel { get; set; }
        public string Status { get; set; }
        public double ScheduledTimeDeparture { get; set; }
        public double ActualTimeDeparture { get; set; }
        public double ScheduledTimeArrival { get; set; }
        public double ActualTimeArrival { get; set; }
    }
}

using System;


namespace CovidInfoPH.Models
{
    public class Patient
    {
        public int Age { get; set; }
        public DateTime DateConfirmed { get; set; }
        public DateTime? DateRecovered { get; set; }
        public DateTime? DateDied { get; set; }
        public string Region { get; set; } 
        public string Province { get; set; }
        public string City { get; set; }
    }
}
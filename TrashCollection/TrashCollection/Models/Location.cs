using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Location
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        public string Zip { get; set; }
        //public string Country { get; set; }
        public string CountryName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<Country> Countries { get; set; }
        public string CountryCode { get; set; }
        public string MapReference { get; set; }

        public string DisplayAddress
        {
            get
            {
                string dspAddress =
                    string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
                string dspCity =
                    string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
                string dspState =
                    string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
                string dspPostalCode =
                    string.IsNullOrWhiteSpace(this.Zip) ? "" : this.Zip;
                return string
               .Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
            }
            #endregion
        }

        public class Country
        {
            #region Properties  
            public int CountryId { get; set; }
            public string CountryName { get; set; }
            public string MapReference { get; set; }
            public string CountryCode { get; set; }
            public string CountryCodeLong { get; set; }
            #endregion
        }
    }
}
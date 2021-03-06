﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collection.Models
{
    public class Pickup
    {
        
        [Key, ForeignKey("Service")]
        public int ServiceId { get; set; }
        //public int PickupId { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        public string Zip { get; set; }
        //public float Latitude { get; set; }
        //public float Longitude { get; set; }
        
        public virtual Service Service { get; set; }

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
            
        }

    }
}
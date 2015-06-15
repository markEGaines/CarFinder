using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFinder.Models
{
    public class Car
    {
        public Car()
        { }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model_name { get; set; }
        public string Model_trim { get; set; }
        public string Model_year { get; set; }
        public string Body_style { get; set; }
        public string Engine_position { get; set; }
        public string Engine_cc { get; set; }
        public string Engine_num_cyl { get; set; }
        public string Engine_type { get; set; }
        public string Engine_valves_per_cyl { get; set; }
        public string Engine_power_ps { get; set; }
        public string Engine_power_rpm { get; set; }
        public string Engine_torque_nm { get; set; }
        public string Engine_torque_rpm { get; set; }
        public string Engine_bore_mm { get; set; }
        public string Engine_stroke_mm { get; set; }
        public string Engine_compression { get; set; }
        public string Engine_fuel { get; set; }
        public string Top_speed_kph { get; set; }
        public string Zero_to_100_kph { get; set; }
        public string Drive_type { get; set; }
        public string Transmission_type { get; set; }
        public string Seats { get; set; }
        public string Doors { get; set; }
        public string Weight_kg { get; set; }
        public string Length_mm { get; set; }
        public string Width_mm { get; set; }
        public string Height_mm { get; set; }
        public string Wheelbase { get; set; }
        public string Lkm_hwy { get; set; }
        public string Lkm_mixed { get; set; }
        public string Lkm_city { get; set; }
        public string Fuel_capacity_l { get; set; }
        public string Sold_in_US { get; set; }
        public string Co2 { get; set; }
        public string Make_display { get; set; }
    }
}
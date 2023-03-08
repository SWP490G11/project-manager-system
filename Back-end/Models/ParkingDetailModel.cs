﻿namespace Back_end.Models
{
    public class ParkingDetailModel
    {
        public string CarID { get; set; }

        public string SlotID { get; set; }

        public string TimeFrameID { get; set; }

        public DateTime ParkingDate { get; set; }

        public DateTime PickUpDate { get; set; }
        public string? Note { get; set; }

        public DateTime LastModifyAt { get; set; }

     
    }

}

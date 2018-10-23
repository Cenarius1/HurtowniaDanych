using System;

namespace HurtowaniaDanych.Domain {
    public class CarTopic : Car {
        public Guid Id { get; set; }
        public DateTime LayerDate { get; set; }
    }
}

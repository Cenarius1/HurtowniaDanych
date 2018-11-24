using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HurtowniaDanych.Advertisement.Models
{
    public class Features
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        [JsonProperty("abs")]
        public bool Abs { get; set; }
       

    }
}

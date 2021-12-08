﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoAdmin.Data
{
    public class RegistredUser : IModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Organization { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Title { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string State { get; set; }
    }
}

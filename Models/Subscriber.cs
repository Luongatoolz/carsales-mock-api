using System;
using System.ComponentModel.DataAnnotations;

namespace CarsalesMockApi
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
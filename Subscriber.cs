using System;
using System.ComponentModel.DataAnnotations;

namespace carsales_mock_api
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
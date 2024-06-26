﻿using System.ComponentModel.DataAnnotations;

namespace testAPI.DTOs.Clients
{
    public class ClientDTO
    {
        // public int ClientId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Name not valid")]
        public required string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "Nom Trop Court")]
        public required string LastName { get; set; }
    }
}

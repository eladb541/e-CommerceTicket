﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETickets5._0.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; } 
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //relationships
        public List<Actor_Movie> Actor_Movies { get; set; }



    }
}
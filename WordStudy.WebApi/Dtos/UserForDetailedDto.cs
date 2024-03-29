﻿        using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data.Model;

namespace WordStudy.WebApi.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Knowns { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhotoUrl { get; set; }

        public ICollection<PhotoForDetailedDto> Photos { get; set; }
    }
}

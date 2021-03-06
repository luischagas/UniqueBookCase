﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UniqueBookCase.DomainModel.AuthorAggregate
{
    [JsonObject(IsReference = true)]
    public class Author : EntityBase
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Document { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}

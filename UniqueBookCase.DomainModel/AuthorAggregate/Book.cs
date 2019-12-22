using System;

namespace UniqueBookCase.DomainModel.AuthorAggregate
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public Guid AuthorId { get; set; }

        /* EF Relation */
        public Author Author { get; set; }

    }
}

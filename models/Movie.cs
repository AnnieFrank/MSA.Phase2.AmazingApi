using System;
namespace MSA.Phase2.AmazingApi.model
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public DateTime DateOfRelease { get; set; }
    }
}


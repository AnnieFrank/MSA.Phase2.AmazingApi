using System;
using Microsoft.EntityFrameworkCore;
using MSA.Phase2.AmazingApi.model;

namespace MSA.Phase2.AmazingApi.models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie>? Movies { get; set; } = null;
    }
}


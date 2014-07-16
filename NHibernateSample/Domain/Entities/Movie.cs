using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateSample.Domain.Entities
{
    public class Movie
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
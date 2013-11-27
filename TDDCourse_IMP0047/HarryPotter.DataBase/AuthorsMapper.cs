using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HarryPotter.Domain;

namespace HarryPotter.DataBase
{
    public class AuthorsMapper : ClassMap<Author>
    {
        public AuthorsMapper()
        {
            Table("authors");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
        }
    }
}

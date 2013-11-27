using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using HarryPotter.Domain;

namespace HarryPotter.DataBase
{
    public class BooksMapper : ClassMap<Book>
    {
        public BooksMapper()
        {
            Table("books");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
            Map(x => x.Price);
            References(x => x.Author);
        }
    }
}

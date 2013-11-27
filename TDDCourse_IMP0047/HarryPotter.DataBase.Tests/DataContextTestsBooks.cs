using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImproveIT.Data;
using NDbUnit.Core;
using NUnit.Framework;
using System.Configuration;
using HarryPotter.Domain;
using System.Data;

namespace HarryPotter.DataBase.Tests
{
    class DataContextTestsBooks
    {
        private IDataContext _dataContext;
        private INDbUnitTest _ndbUnitTest;

        [SetUp]
        public void Setup()
        {
            string cnn = ConfigurationManager.ConnectionStrings["storedb_development"].ConnectionString;
            this._ndbUnitTest = new NDbUnit.Core.SqlClient.SqlDbUnitTest(cnn);
            this._ndbUnitTest.ReadXmlSchema("StoreSchema.xsd");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.DeleteAll);

            NHibernate.ISession session = HarryPotter.Database.DataContextBuilder.BuildSession();
            this._dataContext = new ImproveIT.Data.Hibernate.HibernateDataContext(session);
        }

        [Test]
        public void Add_NoBooksInDatabase3Author_OneBookInsertedWithAuthor()
        {
            //Arrange
            this._ndbUnitTest.ReadXml("Data/Authors.xml");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.Insert);
            Author author = this._dataContext.GetById<Author>(1);

            //Act
            Book book = new Book() { Name = "Book 01", Price = 8, Author = author };
            this._dataContext.Add<Book>(book);

            //Assert
            DataSet dataSet = this._ndbUnitTest.GetDataSetFromDb();
            Assert.AreEqual(3, dataSet.Tables["authors"].Rows.Count);
            Assert.AreEqual(1, dataSet.Tables["books"].Rows.Count);

            DataRow bookDataRow = dataSet.Tables["books"].Rows[0];
            Assert.AreEqual(1, bookDataRow["author_id"]);
        }

        [Test]
        public void GetById_OneBooksInDatabase3Authors_OneBookRetrived()
        {
            //Arrange
            this._ndbUnitTest.ReadXml("Data/Authors.xml");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.Insert);
            this._ndbUnitTest.ReadXml("Data/Books.xml");
            this._ndbUnitTest.PerformDbOperation(NDbUnit.Core.DbOperationFlag.Insert);

            //Act
            Book book = this._dataContext.GetById<Book>(1);

            //Assert
            Assert.IsNotNull(book);
            Assert.IsNotNull(book.Author);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Data.Contexts;
using Bakery.Data.Interfaces;
using Bakery.Data.Factories;
using System.Text.RegularExpressions;

namespace Bakery.TestData
{
    [TestClass]
    [DeploymentItem(@"Database1.mdf")]
    public class LINQ_SQL_data_test
    {
        private static string m_ConnectionString;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"Database1.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security=True;Connect Timeout=30;";
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using var context = new DataClasses1DataContext(m_ConnectionString);
            context.TruncateAllData();
        }


        [TestMethod]
        public void CatalogConstructorTest()
        {
            using var _dbcontext = new DataClasses1DataContext(m_ConnectionString);

            Assert.IsNotNull(_dbcontext.Connection);
            Assert.AreEqual(0, _dbcontext.Catalog.Count());
            Assert.AreEqual(0, _dbcontext.State.Count());

            List<ICatalog> catalogs = new List<ICatalog>()
            {
                CatalogFactory.Create("bread", "pita"),
                CatalogFactory.Create("bread", "baguette"),
                CatalogFactory.Create("bread", "ciabatta")
            };

            List<IState> states = new List<IState>()
            {
                StateFactory.Create("baked", catalogs[0].Id),
                StateFactory.Create("sold", catalogs[1].Id),
                StateFactory.Create("expired", catalogs[2].Id),
            };

            _dbcontext.AddCatalogs(catalogs);
            _dbcontext.AddStates(states);

            Assert.AreEqual(3, _dbcontext.Catalog.Count());
            Assert.AreEqual(3, _dbcontext.State.Count());
        }

        [TestMethod]
        public void FilterCatalogsByName_ForEachTest()
        {
            using var _dbcontext = new DataClasses1DataContext(m_ConnectionString);

            List<ICatalog> catalogs = new List<ICatalog>()
            {
                CatalogFactory.Create("bread", "pita"),
                CatalogFactory.Create("croissant", "chocolate"),
                CatalogFactory.Create("croissant", "buttery")
            };

            _dbcontext.AddCatalogs(catalogs);

            var filtered = _dbcontext.FilterCatalogByName_ForEach("croissant").ToList();

            Assert.AreEqual(2, filtered.Count);
            foreach (var c in filtered)
                Assert.AreEqual("croissant", c.Name);
        }



        [TestMethod]
        public void FilterPersonsByLastName_QuerySyntaxTest()
        {
            using (DataClasses1DataContext _dbcontext = new DataClasses1DataContext(m_ConnectionString))
            {
                try
                {
                    List<ICatalog> catalogs = new List<ICatalog>()
                    {
                        CatalogFactory.Create("bread", "pita"),
                        CatalogFactory.Create("croissant", "chocolate"),
                        CatalogFactory.Create("croissant", "buttery")
                    };

                    _dbcontext.AddCatalogs(catalogs);
                    
                    IEnumerable<Catalog> _filtered = _dbcontext.FilterCatalogByName_QuerySyntax("croissant");
                    Type _returnedType = _filtered.GetType();
                    Assert.AreEqual<string>("System.Data.Linq.DataQuery`1", $"{_returnedType.Namespace}.{_returnedType.Name}");
                    
                    var expected = "SELECT [t0].[Id], [t0].[Name], [t0].[Description] FROM [dbo].[Catalog] AS [t0] WHERE [t0].[Name] = @p0";
                    var actual = Regex.Replace(_filtered.ToString(), @"\s+", " ").Trim();
                    Assert.AreEqual(expected, actual);

                    Assert.AreEqual(2, _filtered.Count());
                    foreach (Catalog c in _filtered)
                        Assert.AreEqual("croissant", c.Name);
                }
                finally
                {
                    _dbcontext.TruncateAllData();
                }
            }
        }


        [TestMethod]
        public void FilterPersonsByLastName_MethodSyntaxTest()
        {
            using (DataClasses1DataContext _dbcontext = new DataClasses1DataContext(m_ConnectionString))
            {
                try
                {
                    List<ICatalog> catalogs = new List<ICatalog>()
                    {
                        CatalogFactory.Create("bread", "pita"),
                        CatalogFactory.Create("croissant", "chocolate"),
                        CatalogFactory.Create("croissant", "buttery")
                    };

                    _dbcontext.AddCatalogs(catalogs);

                    IEnumerable<Catalog> _filtered = _dbcontext.FilterCatalogByName_MethodSyntax("croissant");
                    Type _returnedType = _filtered.GetType();
                    Assert.AreEqual<string>("System.Data.Linq.DataQuery`1", $"{_returnedType.Namespace}.{_returnedType.Name}");


                    string actual = Regex.Replace(_filtered.ToString(), @"\s+", " ").Trim();
                    string expected = "SELECT [t0].[Id], [t0].[Name], [t0].[Description] FROM [dbo].[Catalog] AS [t0] WHERE [t0].[Name] = @p0";
                    Assert.AreEqual(expected, actual);

                    Assert.AreEqual(2, _filtered.Count());
                    foreach (Catalog c in _filtered)
                        Assert.AreEqual("croissant", c.Name);
                }
                finally
                {
                    _dbcontext.TruncateAllData();
                }
            }
        }
    }

}

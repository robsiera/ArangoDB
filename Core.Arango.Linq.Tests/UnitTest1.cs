using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Arango.Protocol;
using Xunit;

namespace Core.Arango.Linq.Tests
{
    public class Project
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class UnitTest1 : IAsyncLifetime
    {
        protected readonly ArangoContext Arango =
            new ArangoContext($"Server=http://localhost:8529;Realm=CI-{Guid.NewGuid():D};User=root;Password=;");

        /*[Fact]
        public async Task Test3()
        {
            var test = await Arango.AsQueryable<Project>("test").Where( x=>x.Name == "A").Select(x => x.Name).ToListAsync();
        }*/

        [Fact]
        public void Test4()
        {
            var list = new List<int> { 1, 2, 3 };
            var test = Arango.AsQueryable<Project>("test").Where(x => list.Contains(x.Value)).ToList();
        }

        /*[Fact]
        public void Test5()
        {
            var test = Arango.AsQueryable<Project>("test").Where( x=> x.Value == 1 || x.Value == 2).ToList();
        }*/

        public async Task InitializeAsync()
        {
            await Arango.CreateDatabaseAsync("test");
            await Arango.CreateCollectionAsync("test", nameof(Project), ArangoCollectionType.Document);
        }

        public async Task DisposeAsync()
        {
            try
            {
                foreach (var db in await Arango.ListDatabasesAsync())
                    await Arango.DropDatabaseAsync(db);
            }
            catch
            {
                //
            }
        }

        [Fact]
        public void Test1()
        {
            var test = Arango.AsQueryable<Project>("test").SingleOrDefault(x => x.Name == "A");
        }

        [Fact]
        public void Test2()
        {
            var test = Arango.AsQueryable<Project>("test").Where(x => x.Name == "A").Select(x => x.Name).ToList();
        }
    }
}
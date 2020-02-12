using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Core.Arango.Protocol;
using Xunit;

namespace Core.Arango.Tests
{
    public class UpdateTest : TestBase
    {
        [Fact]
        public async Task Collection()
        {
            await Arango.RefreshJwtAuth();

            /*await Arango.CreateDatabaseAsync("update");

            await Arango.CreateCollectionAsync("update", "collection", ArangoCollectionType.Document);

            await Arango.CreateDocumentAsync("update", "collection", new
            {
                Key = "abc",
                Name = "a"
            });*/

            var res = await Arango.UpdateDocumentAsync("update", "collection", new
            {
                Key = "abc",
                Name = "c"
            }, returnNew: true, returnOld: true);

            res.ToString();
        }
    }
}

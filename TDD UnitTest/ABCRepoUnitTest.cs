using ABC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_UnitTest
{
    [TestFixture]
    internal class ABCRepoUnitTest
    {

        [Test]
        public void RepositoryShouldReturnDataList()
        {

            ABCDatabase db = new ABCDatabase();
            Assert.True(db.DFWGateLoungeFlight?.Count > 0);


        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plutus.Library.Data;

namespace Plutus.Library.Tests {
    [TestClass]
    public class EntryContextTests {
        [TestMethod]
        public void TestMethod1() {
            EntryContext context = new EntryContext();

            Random random = new Random();

            for (int i = 0 ; i < 100 ; i++) {


                Entry entry = new Entry() { Value = (100 * random.NextDouble()) * (random.NextDouble() > 0.5 ? -1 : 1), CreatedDateTime = DateTime.Now.AddDays(-i) };

                context.Entries.Add(entry);
            }

            context.SaveChanges();
        }
    }
}

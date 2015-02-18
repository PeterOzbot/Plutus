using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plutus.Library.Data;

namespace Plutus.Library.Tests {
    [TestClass]
    public class EntryContextTests {
        [TestMethod]
        public void CreatesSampleData() {
           return;

            EntryContext context = new EntryContext();

            Random random = new Random();

            for (int i = 0 ; i < 300 ; i++) {


                Entry entry = new Entry() { Value = (100 * random.NextDouble()) * (random.NextDouble() > 0.5 ? -1 : 1), CreatedDateTime = DateTime.Now.AddHours(-i * 12) };

                context.Entries.Add(entry);
            }

            context.SaveChanges();
        }
    }
}

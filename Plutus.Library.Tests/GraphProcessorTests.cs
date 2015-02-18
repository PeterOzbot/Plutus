using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plutus.Library.Graph;
using Plutus.Portable.Data;
using System.Linq;
using Plutus.Portable.Graph;

namespace Plutus.Library.Tests {
    /// <summary>
    /// TODO
    /// </summary>
    public static class TestPointExtensions {
        /// <summary>
        /// TODO
        /// </summary>
        public static double Sum(this IPoint point) {
            Point realPoint = point as Point;
            return realPoint.Y.Positive + realPoint.Y.Negative;
        }
    }
    /// <summary>
    /// TODO
    /// </summary>
    [TestClass]
    public class GraphProcessorTests {
        /// <summary>
        /// TODO
        /// </summary>
        public class TestEntry : IEntry {
            /// <summary>
            /// TODO
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// TODO
            /// </summary>
            public DateTime CreatedDateTime { get; set; }
            /// <summary>
            /// TODO
            /// </summary>
            public double Value { get; set; }
            /// <summary>
            /// TODO
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// TODO
            /// </summary>
            public EntryType Type { get { return Value > 0 ? EntryType.Positive : EntryType.Negative; } }
        }




        /// <summary>
        /// Tests if entries are split into days correctly
        /// </summary>
        [TestMethod]
        public void Test_BasicSpliting_Calculation() {

            List<IEntry> entries = new List<IEntry>();
            Random random = new Random();
            for (int i = 0 ; i < 50 ; i++) {
                entries.Add(new TestEntry() { ID = i, Description = i.ToString() + "Desc", Value = random.NextDouble() * 100, CreatedDateTime = new DateTime(2015, 1, 1).AddHours(i * 12) });
            }

            GraphProcessor graphProcessor = new GraphProcessor();
            foreach (IEntry entry in entries) {
                graphProcessor.Process(entry);
            }
            graphProcessor.Finish();

            // if 50 entries are created by 12h difference there should be 25 points
            Assert.AreEqual(25, graphProcessor.Result.Count());
        }

        /// <summary>
        /// Tests if entries are split into days correctly with one last point created from single entry
        /// </summary>
        [TestMethod]
        public void Test_SplitingLast_Calculation() {

            List<IEntry> entries = new List<IEntry>();
            Random random = new Random();
            for (int i = 0 ; i < 50 ; i++) {
                entries.Add(new TestEntry() {
                    ID = i,
                    Description = i.ToString() + "Desc",
                    Value = random.NextDouble() * 100,
                    CreatedDateTime = new DateTime(2015, 1, 1).AddHours(i * 12)
                });
            }

            // add one more, this will be last and one point from this last value will be created
            entries.Add(new TestEntry() {
                ID = 51,
                Description = 51.ToString() + "Desc",
                Value = random.NextDouble() * 100,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(51 * 12)
            });

            GraphProcessor graphProcessor = new GraphProcessor();
            foreach (IEntry entry in entries) {
                graphProcessor.Process(entry);
            }
            graphProcessor.Finish();

            // if 50 entries are created by 12h difference there should be 25 points + one last created from single entry
            Assert.AreEqual(26, graphProcessor.Result.Count());
        }

        /// <summary>
        /// Tests if points are calculated correctly
        /// </summary>
        [TestMethod]
        public void Test_Data_Calculation() {

            List<IEntry> entries = new List<IEntry>();
            entries.Add(new TestEntry() {
                ID = 1,
                Description = 1.ToString() + "Desc",
                Value = 10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(12)
            });
            entries.Add(new TestEntry() {
                ID = 2,
                Description = 1.ToString() + "Desc",
                Value = -10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(24)
            });

            entries.Add(new TestEntry() {
                ID = 3,
                Description = 1.ToString() + "Desc",
                Value = 15,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(3 * 12)
            });
            entries.Add(new TestEntry() {
                ID = 4,
                Description = 1.ToString() + "Desc",
                Value = -10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(4 * 12)
            });

            entries.Add(new TestEntry() {
                ID = 5,
                Description = 1.ToString() + "Desc",
                Value = 5,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(5 * 12)
            });

            GraphProcessor graphProcessor = new GraphProcessor();
            foreach (IEntry entry in entries) {
                graphProcessor.Process(entry);
            }
            graphProcessor.Finish();

            // 3 will be created 
            Assert.AreEqual(3, graphProcessor.Result.Count());

            // first must have value 10+ (-10) = 0
            Assert.AreEqual(0, graphProcessor.Result.ElementAt(0).Sum());
            // second must have value 15+ (-10) = 5
            Assert.AreEqual(5, graphProcessor.Result.ElementAt(1).Sum());
            // third must have value 5
            Assert.AreEqual(5, graphProcessor.Result.ElementAt(2).Sum());
        }

        /// <summary>
        /// Tests if points are calculated correctly when they are not ordered
        /// </summary>
        [TestMethod]
        public void Test_DataInputNotOrdered_Calculation() {

            List<IEntry> entries = new List<IEntry>();
            entries.Add(new TestEntry() {
                ID = 5,
                Description = 1.ToString() + "Desc",
                Value = 5,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(5 * 12)
            });
            entries.Add(new TestEntry() {
                ID = 1,
                Description = 1.ToString() + "Desc",
                Value = 10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(12)
            });
            entries.Add(new TestEntry() {
                ID = 3,
                Description = 1.ToString() + "Desc",
                Value = 15,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(3 * 12)
            });
            entries.Add(new TestEntry() {
                ID = 2,
                Description = 1.ToString() + "Desc",
                Value = -10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(24)
            });
            entries.Add(new TestEntry() {
                ID = 4,
                Description = 1.ToString() + "Desc",
                Value = -10,
                CreatedDateTime = new DateTime(2015, 1, 1).AddHours(4 * 12)
            });


            GraphProcessor graphProcessor = new GraphProcessor();
            foreach (IEntry entry in entries) {
                graphProcessor.Process(entry);
            }
            graphProcessor.Finish();

            // 3 will be created 
            Assert.AreEqual(3, graphProcessor.Result.Count());

            // first must have value 10+ (-10) = 0
            Assert.AreEqual(0, graphProcessor.Result.ElementAt(0).Sum());
            // second must have value 15+ (-10) = 5
            Assert.AreEqual(5, graphProcessor.Result.ElementAt(1).Sum());
            // third must have value 5
            Assert.AreEqual(5, graphProcessor.Result.ElementAt(2).Sum());
        }
    }
}

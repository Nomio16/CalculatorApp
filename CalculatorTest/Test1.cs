using CalculatorLibrary;
using CalculatorLibrary.General;
using CalculatorLibrary.Memories;
namespace CalculatorTest
{
    [TestClass]
    public sealed class Test1
    {   

        [TestMethod]
        public void AddMethodTest()
        {
            RealCalculator calc = new RealCalculator();
            calc.Add(5);
            Assert.AreEqual(calc.Result, 5);
        }

        [TestMethod]
        public void SubstructMethodTest()
        {
            RealCalculator calc = new RealCalculator();
            calc.Add(5);
            calc.Subtract(3);
            Assert.AreEqual((double)calc.Result, 2);
        }


        [TestMethod]
        public void ResultClearTest()
        {
            RealCalculator calc = new RealCalculator();
            calc.Add(14);
            calc.Clear();
            Assert.AreEqual(calc.Result, 0);
        }

        [TestMethod]
        public void StoreCountTest()
        {   
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(5);
            calc.Memo.Store(34);
            Assert.AreEqual(calc.Memo.Count, 2);
        }

        [TestMethod]
        public void MemoryRecallAllTest() 
        {
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(10);
            calc.Memo.Store(20);
            calc.Memo.Store(30);

            List<double> values = calc.Memo.RecallAll();
            //Assert.AreEqual(new List<double> { 10, 20, 30 }, values);
            Assert.AreEqual(values.Count, 3);
        }
        [TestMethod]
        public void AddToMemory_IncreasesStoredValue()
        {
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(10);
            calc.Memo.AddToMemory(0, 5);

            Assert.AreEqual(15, calc.Memo.RecallAll()[0]);
        }

        [TestMethod]
        public void SubtractFromMemory_DecreasesStoredValue()
        {
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(10);
            calc.Memo.SubtractFromMemory(0, 3);

            Assert.AreEqual(7, calc.Memo.RecallAll()[0]);
        }
        [TestMethod]
        public void ClearMemoryItem_RemovesSpecificItem()
        {
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(10);
            calc.Memo.Store(20);
            calc.Memo.ClearMemoryItem(0);

            Assert.AreEqual(1, calc.Memo.Count);
        }

        [TestMethod]
        public void StoreClearTest()
        {
            RealCalculator calc = new RealCalculator();
            calc.Memo.Store(23);
            calc.Memo.ClearMemory();
            Assert.AreEqual(calc.Memo.Count, 0);
        }

        [TestMethod]
        public void ComplexTest()
        {
            RealCalculator calc = new RealCalculator();
            calc.Add(1);
            calc.Add(51);
            calc.Memo.Store(calc.Result);
            calc.Subtract(15);
            calc.Memo.Store(calc.Result);
            calc.Memo.SubtractFromMemory(1, 5);
            Assert.AreEqual(calc.Result, 37);
            List<double> values = calc.Memo.RecallAll();
            Assert.AreEqual(values[0], 52);
            Assert.AreEqual(values[1], 32);
        }

    }
}

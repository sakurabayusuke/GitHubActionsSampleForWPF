using Sample.Enums;
using Sample.ViewModels;

namespace SampleTest
{
    [TestClass]
    public class MainViewModelUnitTest
    {
        /// <summary>
        /// Test Addition
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            var vm = new MainWindowViewModel();

            vm.Method = Method.Addition;
            vm.Value1 = "12";
            vm.Value2 = "23";

            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "35");

            vm.Value1 = "-1";
            vm.Value2 = "1";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "0");
        }

        /// <summary>
        /// Test Subtraction
        /// </summary>
        [TestMethod]
        public void TestSubtraction()
        {
            var vm = new MainWindowViewModel();

            vm.Method = Method.Subtraction;
            vm.Value1 = "12";
            vm.Value2 = "23";

            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "-11");

            vm.Value1 = "-1";
            vm.Value2 = "1";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "-2");
        }

        /// <summary>
        /// Test Multiplication
        /// </summary>
        [TestMethod]
        public void TestMultiplication()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            var b = "sss";
            vm.Method = Method.Multiplication;
            vm.Value1 = "12";
            vm.Value2 = "23";

            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "276");

            vm.Value1 = "-1";
            vm.Value2 = "1";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "-1");
        }

        /// <summary>
        /// Test Multiplication
        /// </summary>
        [TestMethod]
        public void TestDivision()
        {
            var vm = new MainWindowViewModel();

            vm.Method = Method.Division;
            vm.Value1 = "50";
            vm.Value2 = "24";

            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "2");

            vm.Value1 = "-1";
            vm.Value2 = "1";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "-1");
        }

        /// <summary>
        /// Test ErrorPattern
        /// </summary>
        [TestMethod]
        public void TestErrorPattern()
        {
            var vm = new MainWindowViewModel();

            vm.Method = Method.Addition;

            // 両方未入力パターン
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "Error");

            // 数字が入力されていないパターン
            vm.Value1 = "aaaa";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "Error");

            vm.Value1 = string.Empty;
            vm.Value2 = "bbbb";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "Error");

            // 0 除算パターン
            vm.Method = Method.Division;
            vm.Value1 = "999";
            vm.Value2 = "0";
            vm.CalCommand.Execute();
            Assert.AreEqual(vm.Result, "Error");
        }
    }
}
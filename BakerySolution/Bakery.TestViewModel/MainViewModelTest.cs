using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Presentation.ViewModel;
using Bakery.Presentation.Model;

namespace Bakery.TestViewModel
{
    [TestClass]
    public class MainViewModelUnitTest
    {
        [TestMethod]
        public void CreatorTestMethod()
        {
            MainViewModel _vm = new MainViewModel(new ModelTestingImpl());
            Assert.IsFalse(String.IsNullOrEmpty(_vm.ActionText));
            Assert.IsNotNull(_vm.MessageBoxShowDelegate);
            Assert.IsNotNull(_vm.DisplayTextCommand);
            Assert.IsNull(_vm.Catalogs);
            Assert.IsNull(_vm.CurrentCatalog);
            Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
        }

        [TestMethod]
        public void MyCommandTest()
        {
            MainViewModel _vm = new MainViewModel(new ModelTestingImpl());
            int _boxShowCount = 0;
            _vm.MessageBoxShowDelegate = (messageBoxText) =>
            {
                _boxShowCount++;
                Assert.AreEqual<string>("ActionText", messageBoxText);
            };
            _vm.ActionText = "ActionText";
            Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
            _vm.DisplayTextCommand.Execute(null);
            Assert.AreEqual<int>(1, _boxShowCount);
        }

        [TestMethod]
        public void ActionTextTestMethod()
        {
            MainViewModel _vm = new MainViewModel(new ModelTestingImpl());
            Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
            _vm.ActionText = String.Empty;
            Assert.IsFalse(_vm.DisplayTextCommand.CanExecute(null));
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Object DataContext = new MainViewModel(new ModelTestingImpl());
            Assert.IsInstanceOfType(DataContext, typeof(INotifyPropertyChanged));
            int executionCount = 0;
            ((INotifyPropertyChanged)DataContext).PropertyChanged += (x, y) => { Assert.AreEqual<string>("ActionText", y.PropertyName); executionCount++; };
            ((MainViewModel)DataContext).ActionText = "dsdafafafdfsfs";
            Assert.AreEqual<int>(1, executionCount);
        }
    }
}

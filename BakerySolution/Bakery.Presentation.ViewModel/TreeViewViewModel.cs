using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bakery.Presentation.ViewModel
{
    public class TreeViewViewModel : ViewModelBase
    {
        #region constructors

        /// <summary>
        /// Creates an instance of the <see cref="TreeViewViewModel"/>
        /// </summary>
        public TreeViewViewModel()
        {
            ShowTreeViewCommand = new RelayCommand(AddRoot, () => !string.IsNullOrEmpty(PathVariable));
            BrowseCommand = new RelayCommand(Browse);
        }

        #endregion constructors

        #region View Model API

        public ObservableCollection<TreeViewModelItem> HierarchicalAreas { get; set; } = new ObservableCollection<TreeViewModelItem>();

        public string PathVariable
        {
            get => m_PathVariable;
            set
            {
                m_PathVariable = value;
                ShowTreeViewCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public ICommand BrowseCommand { get; }
        public RelayCommand ShowTreeViewCommand { get; }

        #endregion View Model API

        #region private

        private string m_PathVariable = string.Empty;
        private Func<string> GetPath { set; get; } = () => "Result of the FileOpenDialog";

        private void AddRoot()
        {
            TreeViewModelItem rootItem = new RootTreeViewItem();
            HierarchicalAreas.Add(rootItem);
        }

        private void Browse()
        {
            PathVariable = GetPath();
        }

        #endregion private
    }
}

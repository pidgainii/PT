using Bakery.Data.Interfaces;
using Bakery.Presentation.Model;
using Bakery.Presentation.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bakery.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region constructors

        /// <summary>
        /// The constructor used by the View sublayer to create the DataContext
        /// </summary>
        public MainViewModel() : this(null) { }

        /// <summary>
        /// The constructor used by the unit tests
        /// </summary>
        /// <param name="dataLayer"></param>
        public MainViewModel(ModelSublayerAPI dataLayer)
        {
            ShowTreeViewMainWindowCommend = new RelayCommand(ShowTreeViewMainWindow);
            FetchDataCommend = new RelayCommand(() => DataLayer = dataLayer ?? ModelSublayerAPI.Create());
            DisplayTextCommand = new RelayCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(m_ActionText));
            m_ActionText = "Text to be displayed on the pop-up";
        }

        #endregion constructors

        #region ViewModel API

        /// <summary>
        /// A list of users exposed on the screen
        /// </summary>
        public ObservableCollection<IPCatalog> Catalogs
        {
            get => m_Catalogs;
            set
            {
                m_Catalogs = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// A selected user
        /// </summary>
        public IPCatalog CurrentCatalog
        {
            get => m_CurrentCatalog;
            set
            {
                m_CurrentCatalog = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// A text entered on the screen using the appropriate text box that is to be displayed by an independent message box
        /// </summary>
        public string ActionText
        {
            get => m_ActionText;
            set
            {
                m_ActionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// An implementation of the <seealso cref="ICommand"/> bonded with a button to open a message box displaying entered text in the associated text box
        /// </summary>
        public RelayCommand DisplayTextCommand
        {
            get; private set;
        }

        /// <summary>
        /// An implementation of the <seealso cref="ICommand"/> bonded with a button to simulate data fetching from the layer beneath.
        /// </summary>
        public ICommand FetchDataCommend
        {
            get; private set;
        }

        /// <summary>
        /// An implementation of the <seealso cref="ICommand"/> bonded with a button to show a new window contaminating a tree view control
        /// </summary>
        public ICommand ShowTreeViewMainWindowCommend
        {
            get; private set;
        }

        /// <summary>
        /// A callback that provides functionality to create a new child window by the layer above avoiding referencing to the types defined by the layer above.
        /// </summary>
        public Func<IWindow> ChildWindow { get; set; }

        /// <summary>
        /// A callback that provides functionality to show a message displacing a text entered in the associated text box.
        /// </summary>
        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the View sublayer");

        #endregion ViewModel API

        #region Private stuff

        private ModelSublayerAPI DataLayer
        {
            get => m_DataLayer;
            set
            {
                m_DataLayer = value;
                Catalogs = new ObservableCollection<IPCatalog>(value.GetCatalogs);
            }
        }

        private ModelSublayerAPI m_DataLayer;
        private IPCatalog m_CurrentCatalog;
        private string m_ActionText;
        private ObservableCollection<IPCatalog> m_Catalogs;

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(ActionText);
        }

        private void ShowTreeViewMainWindow()
        {
            IWindow child = ChildWindow();
            child.Show();
        }

        #endregion Private stuff
    }
}

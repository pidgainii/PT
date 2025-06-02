using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Presentation.ViewModel
{
    public class RootTreeViewItem : TreeViewModelItem
    {
        /// <summary>
        /// Creates and instance of <seealso cref="TreeViewModelItem"/> with the hard-coded name "Root"
        /// </summary>
        public RootTreeViewItem()
        {
            Name = "Root";
        }
    }
}

using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUITreeViewBug
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateTree();
        }

        public ObservableCollection<Item> Items { get; } = new();

        public void Refresh()
        {
            Items.Clear();
            PopulateTree();
        }

        private void PopulateTree()
        {
            foreach (var i in Enumerable.Range(0, 10))
            {
                var item = new Item($"Item {i}");
                foreach (var j in Enumerable.Range(0, 10))
                {
                    item.Items.Add(new Item($"Item {i}.{j}"));
                }
                Items.Add(item);
            }
        }
    }

    public class Item(string name)
    {
        public string Name { get; set; } = name;
        public bool IsExpanded => true;
        public ObservableCollection<Item> Items { get; } = new();
    }
}

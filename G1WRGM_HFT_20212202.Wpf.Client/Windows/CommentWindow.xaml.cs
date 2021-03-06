using G1WRGM_HFT_20212202.Wpf.Client.ViewModels;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace G1WRGM_HFT_20212202.Wpf.Client
{
    /// <summary>
    /// Interaction logic for CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        public CommentWindow(Video video)
        {
            InitializeComponent();
            this.DataContext = new CommentWindowViewModel();
            (this.DataContext as CommentWindowViewModel).Setup(video);
        }
    }
}

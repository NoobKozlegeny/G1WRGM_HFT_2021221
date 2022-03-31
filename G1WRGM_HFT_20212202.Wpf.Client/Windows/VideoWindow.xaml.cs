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
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
    {
        public VideoWindow(YTContentCreator ytcc)
        {
            InitializeComponent();
            this.DataContext = new VideoWindowViewModel();
            (this.DataContext as VideoWindowViewModel).Setup(ytcc);
        }
    }
}

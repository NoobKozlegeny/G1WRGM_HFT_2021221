using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_20212202.Wpf.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows;

namespace G1WRGM_HFT_20212202.Wpf.Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<YTContentCreator> YTCC { get; set; }

        private YTContentCreator selectedYTCC;

        public YTContentCreator SelectedYTCC
        {
            get { return selectedYTCC; }
            set 
            { 
                if (value != null)
                {
                    selectedYTCC = new YTContentCreator()
                    {
                        CreatorName = value.CreatorName,
                        CreatorID = value.CreatorID,
                        Creation = value.Creation,
                        SubscriberCount = value.SubscriberCount,
                        Videos = value.Videos
                    };
                    OnPropertyChanged();
                    (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand OpenCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                YTCC = new RestCollection<YTContentCreator>("http://localhost:42069/", "ytcontentcreator", "hub");

                OpenCommand = new RelayCommand(
                    () => new VideoWindow(SelectedYTCC).ShowDialog(),
                    () => SelectedYTCC != null
                    );

                CreateCommand = new RelayCommand(
                    () => YTCC.Add(new YTContentCreator() 
                    { 
                        CreatorName = SelectedYTCC.CreatorName
                    }));

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            YTCC.Update(SelectedYTCC);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Kaga");
                        } 
                    });

                DeleteCommand = new RelayCommand(
                    () => YTCC.Delete(SelectedYTCC.CreatorID),
                    () => SelectedYTCC != null
                    );

                SelectedYTCC = new YTContentCreator();
            }
        }
    }
}

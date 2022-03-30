using G1WRGM_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G1WRGM_HFT_20212202.Wpf.Client.ViewModels
{
    public class VideoWindowViewModel : ObservableRecipient
    {
        public RestCollection<Video> Videos { get; set; }

        private Video selectedVideo;

        public Video SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                if (value != null)
                {
                    selectedVideo = new Video()
                    {
                        Title = value.Title,
                        VideoID = value.VideoID,
                        CreatorID = value.CreatorID,
                        ViewCount = value.ViewCount,
                        YTContentCreator = value.YTContentCreator,
                        Comments = value.Comments
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

        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public VideoWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Videos = new RestCollection<Video>("http://localhost:42069/", "video", "hub");

                CreateCommand = new RelayCommand(
                    () => Videos.Add(new Video()
                    {
                        Title = SelectedVideo.Title
                    }));

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            Videos.Update(SelectedVideo);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Kaga");
                        }
                    });

                DeleteCommand = new RelayCommand(
                    () => Videos.Delete(SelectedVideo.CreatorID),
                    () => SelectedVideo != null
                    );

                SelectedVideo = new Video()
                {
                    Title = "",
                    CreatorID = 2,
                    ViewCount = 0,
                    Comments = null
                };
            }
        }
    }
}

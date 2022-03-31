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
        //TODO?: Only show the SelectedYTCC's video
        public RestCollection<Video> Videos { get; set; }

        private YTContentCreator selectedYTCC;

        public YTContentCreator SelectedYTCC
        {
            get { return selectedYTCC; }
            set 
            { 
                OnPropertyChanged();
                SetProperty(ref selectedYTCC, value);
            }
        }

        public void Setup(YTContentCreator yTContentCreator)
        {
            SelectedYTCC = yTContentCreator;
        }

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
        public ICommand OpenCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public VideoWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Videos = new RestCollection<Video>("http://localhost:42069/", "video", "hub");

                OpenCommand = new RelayCommand(
                    () => new CommentWindow(SelectedVideo).ShowDialog(),
                    () => SelectedVideo != null
                    );

                CreateCommand = new RelayCommand(
                    () => Videos.Add(new Video()
                    {
                        Title = SelectedVideo.Title,
                        CreatorID = SelectedYTCC.CreatorID,
                        Comments = new List<Comment>(),
                    }));

                UpdateCommand = new RelayCommand(
                    () => Videos.Update(SelectedVideo)
                    );

                DeleteCommand = new RelayCommand(
                    () => Videos.Delete(SelectedVideo.VideoID),
                    () => SelectedVideo != null
                    );

                SelectedVideo = new Video()
                {
                    Title = "",
                    CreatorID = 2,
                    ViewCount = 0,
                    Comments = null
                };

                SelectedYTCC = new YTContentCreator()
                {
                    CreatorName = "Test"
                };
            }
        }
    }
}

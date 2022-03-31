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
    public class CommentWindowViewModel : ObservableRecipient
    {
        public RestCollection<Comment> Comments { get; set; }
        
        private Video selectedVideo;

        public Video SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                OnPropertyChanged();
                SetProperty(ref selectedVideo, value);
            }
        }

        public void Setup(Video video)
        {
            SelectedVideo = video;
        }

        private Comment selectedComment;

        public Comment SelectedComment
        {
            get { return selectedComment; }
            set
            {
                if (value != null)
                {
                    selectedComment = new Comment()
                    {
                        Content = value.Content,
                        CommentID = value.CommentID,
                        Likes = value.Likes,
                        Username = value.Username,
                        VideoID = value.VideoID
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

        public CommentWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Comments = new RestCollection<Comment>("http://localhost:42069/", "Comment", "hub");

                OpenCommand = new RelayCommand(
                    () => new CommentWindow(SelectedVideo).ShowDialog(),
                    () => SelectedComment != null
                    );

                CreateCommand = new RelayCommand(
                    () => Comments.Add(new Comment()
                    {
                        Content = SelectedComment.Content,
                        CommentID = 1
                    }));

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            Comments.Update(SelectedComment);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Kaga");
                        }
                    });

                DeleteCommand = new RelayCommand(
                    () => Comments.Delete(SelectedComment.CommentID),
                    () => SelectedComment != null
                    );

                SelectedComment = new Comment();
            }
        }
    }
}

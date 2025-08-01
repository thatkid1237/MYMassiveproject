using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace Linkedlistsstory.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> Messages { get; } = new();
        public ICommand ChooseOptionCommand { get; }

        private readonly Story _story;

        public ViewModel()
        {
            _story = new Story("adventure.json", "start");

            // Show the starting narrative
            Messages.Add(new Message { Text = _story.CurrentNode.text, IsUser = false });

            // Create the command for the buttons
            ChooseOptionCommand = new RelayCommand(OnChooseOption);
        }

        // Expose the current node so the XAML can bind to CurrentNode.Options
        public StoryNode CurrentNode => _story.CurrentNode;

        private void OnChooseOption(object parameter)
        {
            if (parameter is Option opt)
            {
                // Record the user's choice
                Messages.Add(new Message { Text = opt.choice, IsUser = true });

                // Advance the story
                var nextNode = _story.Advance(opt);
                if (nextNode != null)
                {
                    Messages.Add(new Message { Text = nextNode.text, IsUser = false });

                    // Notify the UI that CurrentNode has changed so the options list refreshes
                    OnPropertyChanged(nameof(CurrentNode));
                }
                else
                {
                    Messages.Add(new Message
                    {
                        Text = "Invalid choice or missing story path. The story ends here.",
                        IsUser = false
                    });
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
    public class Message
    {
        public string Text { get; set; }
        public bool IsUser { get; set; }
    }
}

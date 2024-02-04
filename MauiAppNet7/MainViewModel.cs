using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiAppNet7
{
    internal class MainViewModel
    {
        public ICommand SearchOpenPage { get; private set; }
        public MainViewModel()
        {
            SearchOpenPage = new Command(CommandSearch);
        }

        public async void CommandSearch()
        {
            var page = new ContentPage
            {
                Title = "Search Page Test",
                Content = new Label
                {
                    Text = "New ContentPage"
                }
            };

            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Notify([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    Notify();
                }
            }
        }
    }
}
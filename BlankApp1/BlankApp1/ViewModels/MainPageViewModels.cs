namespace BlankApp1.ViewModels
{
    using System.ComponentModel;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string MyEntry { get; set; }
        public string MyLabel { get; set; } = "test";
        public DelegateCommand BtnCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            BtnCommand = new DelegateCommand(OnButtonClick);
        }

        public void OnButtonClick()
        {
            MyLabel = MyEntry;
            OnPropertyChanged("MyLabel");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

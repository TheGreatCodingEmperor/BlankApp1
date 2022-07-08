namespace BlankApp1.ViewModels
{
    using System;
    using System.ComponentModel;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using PropertyChanged;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string MyQuestion { get; set; }
        public string MyAnswer { get; set; }
        public string MyResult { get; set; }
        public DelegateCommand ReGen { get; set; }
        public DelegateCommand SendAnswer { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public Random rand = new Random();

        public MainPageViewModel(INavigationService navigationService)
        {
            QuestionGen();
            this.navigationService = navigationService;
            ReGen = new DelegateCommand(QuestionGen);
            SendAnswer = new DelegateCommand(OnButtonClick);
        }

        public void QuestionGen()
        {
            Value1 = rand.Next(0,100);
            Value2 = rand.Next(0, 100);
            MyQuestion = $"{Value1} + {Value2} = ?";
            MyAnswer = "";
        }

        public void OnButtonClick()
        {
            if(MyAnswer.Trim() == (Value1+ Value2).ToString())
            {
                MyResult = "恭喜答對!!";
                QuestionGen();
            }
            else
            {
                MyResult = "回答錯誤!!";
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}

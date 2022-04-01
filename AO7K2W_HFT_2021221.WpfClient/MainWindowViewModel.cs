using AO7K2W_HFT_2021221.Models;
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

namespace AO7K2W_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Conflict> Conflicts { get; set; }

        private Conflict selectedConflict;

        public Conflict SelectedConflict
        {
            get { return selectedConflict; }
            set 
            {
                if (value != null)
                {
                    selectedConflict = new Conflict()
                    {
                        NameOfConflict = value.NameOfConflict,
                        DateOfConflict =value.DateOfConflict,
                        Casualties = value.Casualties,
                        Winner = value.Winner,
                        ConflictId  = value.ConflictId
                    };
                    OnPropertyChanged();
                    (DeleteConflictCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateConflictCommand { get; set; }
        public ICommand DeleteConflictCommand { get; set; }
        public ICommand UpdateConflictCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        
        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {
                Conflicts = new RestCollection<Conflict>("http://localhost:26569/", "conflict", "hub");

                CreateConflictCommand = new RelayCommand(() =>
                {
                    Conflicts.Add(new Conflict()
                    {
                        NameOfConflict = SelectedConflict.NameOfConflict,
                        DateOfConflict = SelectedConflict.DateOfConflict,
                        Casualties = SelectedConflict.Casualties,
                        Winner = SelectedConflict.Winner
                    });
                });

                DeleteConflictCommand = new RelayCommand(() =>
                {
                    Conflicts.Delete(SelectedConflict.ConflictId);
                },
                () =>
                {
                    return SelectedConflict != null;
                });

                UpdateConflictCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Conflicts.Update(SelectedConflict);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });
                SelectedConflict = new Conflict();
            }
            
        }
    }
}

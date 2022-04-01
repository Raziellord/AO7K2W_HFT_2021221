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
        public RestCollection<Tank> Tanks { get; set; }

        private Conflict selectedConflict;
        private Tank selectedTank;

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
        public Tank SelectedTank
        {
            get { return selectedTank; }
            set
            {
                if (value != null)
                {
                    selectedTank = new Tank()
                    {
                        TankId = value.TankId,
                        Model = value.Model,
                        Nickname = value.Nickname,
                        Eliminations = value.Eliminations,
                        CrewSpace = value.CrewSpace,
                        StartOfService = value.StartOfService,
                        Conflict = value.Conflict,
                        ConflictId = value.ConflictId,
                    };
                    OnPropertyChanged();
                    (DeleteTankCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateConflictCommand { get; set; }
        public ICommand DeleteConflictCommand { get; set; }
        public ICommand UpdateConflictCommand { get; set; }

        public ICommand CreateTankCommand { get; set; }
        public ICommand DeleteTankCommand { get; set; }
        public ICommand UpdateTankCommand { get; set; }

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
                Tanks = new RestCollection<Tank>("http://localhost:26569/", "tank", "hub");

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


                CreateTankCommand = new RelayCommand(() =>
                {
                    Tanks.Add(new Tank()
                    {
                        Model = SelectedTank.Model,
                        Nickname = SelectedTank.Nickname,
                        Eliminations = SelectedTank.Eliminations,
                        CrewSpace = SelectedTank.CrewSpace,
                        StartOfService = SelectedTank.StartOfService,
                        Conflict = SelectedTank.Conflict,
                        ConflictId = SelectedTank.ConflictId
                    });
                });

                DeleteTankCommand = new RelayCommand(() =>
                {
                    Tanks.Delete(SelectedTank.TankId);
                },
                () =>
                {
                    return SelectedTank != null;
                });

                UpdateTankCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Tanks.Update(SelectedTank);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                SelectedTank = new Tank();
                SelectedConflict = new Conflict();
            }
            
        }
    }
}

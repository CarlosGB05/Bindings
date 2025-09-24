using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using Bindings.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bindings.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private Boligrafo boli = new();

    [ObservableProperty] 
    private Boligrafo boliSeleccionado = new();
    
    // tiene q ser privado y empezar por minuscula y no tener get,set para realizar cambios
    [ObservableProperty]
    private string mensaje = string.Empty;
    
    [ObservableProperty] 
    private bool avanzado = false;
    
    [ObservableProperty]
    private List<Boligrafo> boligrafos = new ();
    
    public string Greeting { get; } = "Welcome to Avalonia!";
    public string Saludo { set; get; } = "Bienvenido!!!!";
    public List<string> ListaColores { set; get; }

    private void CargarCombo()
    {
        ListaColores = new List<string>()
        {
            "Rojo","Azul","Negro"
        };
    }

    private void CargarBolis()
    {
        Boligrafo boli = new();
        boli.Codigo = "1010";
        boli.Color = "Azul";
        Boligrafos.Add(boli);
        
        Boligrafo boli2 = new();
        boli2.Codigo = "2020";
        boli2.Color = "Rojo";
        Boligrafos.Add(boli2);
        
        Boligrafo boli3 = new();
        boli3.Codigo = "3030";
        boli3.Color = "Verde";
        Boligrafos.Add(boli3);
    }

    public MainWindowViewModel()
    {
        CargarCombo();
        CargarBolis();
    }

    [RelayCommand]
    public void ComprobarFecha()
    {
        CheckDate();
    }

    private bool CheckDate()
    {
        if (Boli.Fecha < DateTime.Today)
        {
            Mensaje = "No puedes marcar un dia anterior a hoy";
            return false;
        }
        else
        {
            Mensaje = "";
            return true;
        }
    }

    [RelayCommand]
    public void CargarBoliSeleccionado()
    {
        Boli = BoliSeleccionado;
        ModoCrear = false;
        ModoEditar = true;
    }

    [RelayCommand]
    public void MostrarBoli(object parameter)
    {
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes marcar el check";
            Console.WriteLine("Debes marcar el check");
            check.Foreground = Brushes.Red;
            check.FontWeight = FontWeight.Bold;
            return;
        }

        if (CheckDate() is false)
        {
            Mensaje = "Fecha Incorrecta";
            return;
        }

        if (string.IsNullOrWhiteSpace(Boli.Codigo))
        {
            Mensaje = "Debes marcar el codigo";
        }
        else
        {
            // Aqui se crea el boli
            Console.WriteLine(Boli.Codigo+" "+Boli.Color);
            Boligrafos.Add(Boli);
            Boli = new Boligrafo();
            check.IsChecked = false;
        }

        
    }
    [RelayCommand]
    public void MostarOpcionAvanzado()
    {
        if (Avanzado == false)
        {
            Avanzado = true;
        }
        else
        {
            Avanzado = false;
        }
    }

    [RelayCommand]
    public void MostrarCondiciones(object parameter) {
        CheckBox check = (CheckBox)parameter;
        if (check.IsChecked is true)
        {
            check.Foreground = Brushes.Black;
            check.FontWeight = FontWeight.Normal;
        }
        else
        {
            check.Foreground = Brushes.Red;
            check.FontWeight = FontWeight.Bold;
        }
    }
    
    [ObservableProperty]
    private bool modoEditar = false;
    
    [ObservableProperty]
    private bool modoCrear = true;
    

}
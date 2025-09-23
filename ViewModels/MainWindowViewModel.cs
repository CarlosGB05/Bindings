using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bindings.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bindings.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private Boligrafo boli = new();
    
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
        boli2.Codigo = "1010";
        boli2.Color = "Azul";
        Boligrafos.Add(boli2);
        
        Boligrafo boli3 = new();
        boli3.Codigo = "1010";
        boli3.Color = "Azul";
        Boligrafos.Add(boli3);
    }

    public MainWindowViewModel()
    {
        CargarCombo();
        CargarBolis();
    }

    [RelayCommand]
    public void MostrarBoli(object parameter)
    {
        if (parameter is false)
        {
            Mensaje = "Debes marcar el check";
            return;
        }

        if (string.IsNullOrWhiteSpace(Boli.Codigo))
        {
            Mensaje = "Debes marcar el codigo";
        }
        else
        {
            Console.WriteLine(Boli.Codigo+" "+Boli.Color);
            Boligrafos.Add(Boli);
            Boli = new Boligrafo();
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

}
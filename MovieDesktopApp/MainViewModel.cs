using MovieRental.Movie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

public class MainViewModel
{
    public ObservableCollection<Movie> Movies { get; set; }

    public MainViewModel()
    {
        //List as example
        Movies = new ObservableCollection<Movie>
        {
            new Movie { Id = 1, Title = "The Matrix" },
            new Movie { Id = 2, Title = "Inception" },
            new Movie { Id = 3, Title = "Interstellar" }
        };
    }
}
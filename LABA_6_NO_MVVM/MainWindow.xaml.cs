using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace лаба_6_норм
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> all_movies = new List<Movie>
        {
            new Movie{Name = "Остров проклятых", Genre = Genre.Триллер, Director =
                 new Director{
                    Name = "Nolan", StartActivityYear = 1991, EndActivityYear = 2008
                    }, Publish_year = 2001, Rate = 10.0
            },
            new Movie{Name = "Остров проклятых2", Genre = Genre.Абсурдистский, Director =
                new Director{
                    Name = "Nolan", StartActivityYear = 1991, EndActivityYear = 2008
                }, Publish_year = 2006, Rate = 9.5
            }
        };
        ObservableCollection<Movie> movies = new ObservableCollection<Movie>
        {
            new Movie{Name = "Остров проклятых", Genre = Genre.Триллер, Director =
                 new Director{
                    Name = "Nolan", StartActivityYear = 1991, EndActivityYear = 2008
                    }, Publish_year = 2001, Rate = 10.0
            },
            new Movie{Name = "Остров проклятых2", Genre = Genre.Абсурдистский, Director =
                new Director{
                    Name = "Nolan", StartActivityYear = 1991, EndActivityYear = 2008
                }, Publish_year = 2006, Rate = 9.5
            }
        };
        public MainWindow()
        {
            InitializeComponent();
            InitGenreBoxes(GenreComboBox);
            InitGenreBoxes(GenreComboBox2);
        }
        private void InitGenreBoxes(ComboBox comboBox)
        {
            comboBox.ItemsSource = Enum.GetValues(typeof(Genre))
                                      .Cast<Genre>()
                                      .ToList();
            comboBox.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            double rate = double.Parse(Rate_TB.Text);
            int publish_year = int.Parse(Publish_year_TB.Text);
            Director director = new Director()
            {
                Name = Director_TB.Text,
                StartActivityYear = publish_year,
                EndActivityYear = publish_year
            };
            Genre selectedGenre = (Genre)GenreComboBox.SelectedItem;

            Movie movie = new Movie
            {
                Name = Film_name_TB.Text,
                Genre = selectedGenre,
                Publish_year = publish_year,
                Rate = rate,
                Director = director
            };
            var existing = movies.FirstOrDefault(m => m.Name == Film_name_TB.Text &&
            m.Genre == selectedGenre &&
            m.Publish_year == publish_year &&
            m.Rate == rate &&
            m.Director.Name == director.Name);
            if (existing != null)
                MessageBox.Show("Фильм уже добавлен!");
            else
                movies.Add(movie);
                all_movies.Add(movie);  
            director.AddRate(rate);
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            double rate = double.Parse(Rate_TB.Text);
            int publish_year = int.Parse(Publish_year_TB.Text);
            Director director = new Director()
            {
                Name = Director_TB.Text,
                StartActivityYear = publish_year,
                EndActivityYear = publish_year
            };
            Genre selectedGenre = (Genre)GenreComboBox.SelectedItem;
            var existing = movies.FirstOrDefault(m => m.Name == Film_name_TB.Text &&
            m.Genre == selectedGenre &&
            m.Publish_year == publish_year &&
            m.Rate == rate &&
            m.Director.Name == director.Name);
            if (existing != null)
            {
                movies.Remove(existing);
            }
            else
            {
                MessageBox.Show("Нет такого фильма!");
            }
        }
        private void Show_all_Click(object sender, RoutedEventArgs e)
        {
            moviesDataGrid.ItemsSource = movies;
        }
        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            Genre selectedGenre = (Genre)GenreComboBox2.SelectedItem;
            all_movies = (all_movies.Where(m => m.Genre == selectedGenre).Select(m => m).ToList());
            moviesDataGrid.ItemsSource = all_movies;
        }
        private void Relize_Click(object sender, RoutedEventArgs e)
        {
            int rel_start = int.Parse(From_rel_TB.Text);
            int rel_end = int.Parse(To_rel_TB.Text);

            all_movies = all_movies.Where(m => m.Publish_year >= rel_start && m.Publish_year <= rel_end).Select(m => m).ToList();
            moviesDataGrid.ItemsSource = all_movies;
        }
        private void Sort_incr_Click(object sender, RoutedEventArgs e)
        {
            all_movies = all_movies.OrderBy(m => m.Rate).ToList();
            moviesDataGrid.ItemsSource = all_movies;
        }
        private void Sort_desc_Click(object sender, RoutedEventArgs e)
        {
            all_movies = all_movies.OrderByDescending(m => m.Rate).ToList();
            moviesDataGrid.ItemsSource = all_movies;
        }
        private void Form_Click(object sender, RoutedEventArgs e)
        {
            var stats = movies
                .GroupBy(m => m.Director.Name)
                .Select(g => new
                {
                    Name = g.Key,
                    FilmCount = g.Count(),
                    AverageRate = g.Average(m => m.Rate),
                    StartActivityYear = g.Min(m => m.Publish_year),
                    EndActivityYear = g.Max(m => m.Publish_year)
                }).ToList();

            directorsDataGrid.ItemsSource = stats;
        }

    }
}
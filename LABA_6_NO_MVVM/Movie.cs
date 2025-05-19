﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_6_норм
{
    internal enum Genre
    {
        Боевик, Приключенческий, Комедия, Драма, Криминальный, Ужасы, Фэнтези, Романтика, Триллер, Анимация, Семейный, Военный, Документальный, Мюзикл, Биография, Научная_фантастика, Вестерн, Постапокалипсис, Детектив, Нуар, Гангстер, Ограбление, Загадка, Экспериментальный, Абсурдистский, Блэксплойтейшн, Бадди, Криминальная_комедия, Погоня, Заговор, Шпионский, Праздничный, Вдохновляющий, Судебный, Медицинский, Мелодрама, Политический, Тюремный, Психологический, Религиозный, Дорожный, Романтический, Повседневный, Спортивный, Супергеройский, Напряжённый, Подростковый, Зомби
    }
    internal class Movie
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int Publish_year { get; set; }
        public Director Director { get; set; }
        public double Rate { get; set; }

    }
}
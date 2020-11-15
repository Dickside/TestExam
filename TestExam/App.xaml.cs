﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestExam
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DB.ONIEntities2 Entities = new DB.ONIEntities2();

        public static event Action OnUpdated;

        public static void UpdateDB()
        {
            OnUpdated?.Invoke();
        }
    }
}

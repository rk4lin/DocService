﻿using System;
using System.Collections.Generic;
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

namespace DocClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Method();
            
        }


        private void Method()
        {
            var result = DocPresenter.Request();
            var listDocs = new List<DocModel>();
            DocModel docModel;


            foreach (var item in result)
            {
                var after = item.lastUpdateDate.AddDays(60);

                docModel = new DocModel()
                {
                    docNumber = item.docNumber,
                    dateDoc = item.dateCreateDocument.ToShortDateString(),
                    lastUpdateDate = item.lastUpdateDate.ToShortDateString(),
                    checkDateUpdate = after < DateTime.Now ? true : false
                };

                listDocs.Add(docModel);
            }
                       
             documentsGrid.ItemsSource = listDocs;
        }
    }
}

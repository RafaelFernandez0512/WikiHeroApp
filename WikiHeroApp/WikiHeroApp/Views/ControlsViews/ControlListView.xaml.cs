﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHeroApp.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlListView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
          nameof(ItemsSource),
          typeof(IList),
          typeof(ControlListView),
          propertyChanged: ColletionViewChanged);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(ColorFrame), typeof(Color),
            typeof(ControlListView));
        public static readonly BindableProperty SelectItemProperty = BindableProperty.Create(
        nameof(SelectItem),
        typeof(object),
        typeof(ControlListView),
        propertyChanged: SelectItemChanged);
        public object SelectItem
        {
            get => GetValue(SelectItemProperty);
            set => SetValue(SelectItemProperty, value);
        }

        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ControlListView control)) return;
            var items = newValue;
            control.PublisherList.SelectedItem = (object)items;
        }
        public Color ColorFrame
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        private static void ColletionViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ControlListView control)) return;
            var items = (IList)newValue;
            control.PublisherList.ItemsSource = items;
        }
        public ControlListView()
        {
            InitializeComponent();
        }
    }
}
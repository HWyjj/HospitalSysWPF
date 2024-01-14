using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace HospitalSysWPF.Common
{
    public class PasswordBoxHelper
    {
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }
        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnPropertyChanged));
        /// <summary>
        /// 通过设置该属性的OnPropertyChanged将改变通知到PasswordBox.Password,
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;
            box.PasswordChanged -= OnPasswordChanged;
            var password = (string)e.NewValue;
            if (box != null && box.Password != password)
                box.Password = password;
            box.PasswordChanged += OnPasswordChanged;
        }
        /// <summary>
        /// 并通过添加对PasswordBox.PasswordChanged事件的响应来响应PasswordBox.Password的改变。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = sender as PasswordBox;
            SetPassword(box, box.Password);
        }

    }
}

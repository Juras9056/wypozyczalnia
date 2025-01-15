using System;
using System.Windows;
using System.Windows.Controls;

namespace wpf_app.Controls
{
    public partial class DateTimePicker : UserControl
    {
        public DateTimePicker()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register(nameof(SelectedDate), typeof(DateTime?), typeof(DateTimePicker), new PropertyMetadata(DateTime.Now));

        public DateTime? SelectedDateTime
        {
            get
            {
                if (SelectedDate.HasValue &&
                    TimeSpan.TryParse(TimeTextBox.Text, out TimeSpan time))
                {
                    return SelectedDate.Value.Date.Add(time);
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    SelectedDate = value.Value.Date;
                    TimeTextBox.Text = value.Value.TimeOfDay.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    SelectedDate = null;
                    TimeTextBox.Text = string.Empty;
                }
            }
        }

        public DateTime? SelectedDate
        {
            get => (DateTime?)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        public int Hour
        {
            get => SelectedDate?.Hour ?? 0;
            set
            {
                if (SelectedDate.HasValue)
                {
                    SelectedDate = new DateTime(
                        SelectedDate.Value.Year,
                        SelectedDate.Value.Month,
                        SelectedDate.Value.Day,
                        value,
                        SelectedDate.Value.Minute,
                        SelectedDate.Value.Second);
                }
            }
        }

        public int Minute
        {
            get => SelectedDate?.Minute ?? 0;
            set
            {
                if (SelectedDate.HasValue)
                {
                    SelectedDate = new DateTime(
                        SelectedDate.Value.Year,
                        SelectedDate.Value.Month,
                        SelectedDate.Value.Day,
                        SelectedDate.Value.Hour,
                        value,
                        SelectedDate.Value.Second);
                }
            }
        }

        public int Second
        {
            get => SelectedDate?.Second ?? 0;
            set
            {
                if (SelectedDate.HasValue)
                {
                    SelectedDate = new DateTime(
                        SelectedDate.Value.Year,
                        SelectedDate.Value.Month,
                        SelectedDate.Value.Day,
                        SelectedDate.Value.Hour,
                        SelectedDate.Value.Minute,
                        value);
                }
            }
        }
    }
}

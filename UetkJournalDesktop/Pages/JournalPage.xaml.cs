using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
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
using JournalDesktop.Models;

namespace JournalDesktop.Pages
{
    public partial class JournalPage : UserControl
    {
        private List<Mark> _marks;
        private Dictionary<Guid, int> _markValues = new Dictionary<Guid, int>();

        public JournalPage()
        {
            InitializeComponent();

            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:7043/api/Groups/GetAll?teacherId=7a728bcd-1872-48d0-be66-765952dbcd67").Result.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(response);
            var teacherGroups = JsonConvert.DeserializeObject<List<TeacherGroup>>(json["teacherGroups"].ToString());
            cbxGroup.ItemsSource = teacherGroups.Select(x => x.Group).ToList();
            cbxSubject.ItemsSource = teacherGroups.Select(x => x.Subject).ToList();

            response = client.GetAsync("https://localhost:7043/api/Marks/GetAll").Result.Content.ReadAsStringAsync().Result;
            json = JObject.Parse(response);
            _marks = JsonConvert.DeserializeObject<List<Mark>>(json["marks"].ToString());

            foreach (var mark in _marks)
            {
                if (int.TryParse(mark.ShortName, out int value))
                {
                    _markValues.Add(mark.Id, value);
                }
            }

            GenerateJournalTable();
        }

        private void GenerateJournalTable()
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:7043/api/StudentLessons/GetAll?teacherId=7a728bcd-1872-48d0-be66-765952dbcd67&subjectId=7e3860f2-aa2a-4452-ac6d-8bd8bb0aa023&groupId=087d8a8b-2ad9-4431-8475-c9235f4091a8")
                .Result.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(response);
            var studentLessons = JsonConvert.DeserializeObject<List<StudentLesson>>(json["studentLessons"].ToString());
            studentLessons = studentLessons.OrderBy(x => x.LessonDate).ToList();

            response = client.GetAsync("https://localhost:7043/api/Students/GetAll?groupId=087d8a8b-2ad9-4431-8475-c9235f4091a8")
                .Result.Content.ReadAsStringAsync().Result;
            json = JObject.Parse(response);
            var students = JsonConvert.DeserializeObject<List<Student>>(json["students"].ToString());
            students = students.OrderBy(x => x.FullName).ToList();
            
            grdMarks.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
            for (int i = 0; i < students.Count; i++)
            {
                grdMarks.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
            }
            grdMarks.Height = grdMarks.RowDefinitions.Count * 25;

            grdMarks.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            grdMarks.Children.Add(new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = new TextBlock() { Text = "Студенты", TextAlignment = TextAlignment.Center }
            });

            grdMarks.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(70) });
            var brd = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = new TextBlock() { Text = "Средний балл", TextWrapping = TextWrapping.Wrap, FontSize = 11, TextAlignment = TextAlignment.Center }
            };
            brd.SetValue(Grid.ColumnProperty, 1);
            grdMarks.Children.Add(brd);

            var cnt = studentLessons.GroupBy(x => x.LessonId);
            for (int i = 0; i < studentLessons.GroupBy(x => x.LessonId).Count(); i++)
            {
                grdMarks.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            }
            grdMarks.Width = (grdMarks.ColumnDefinitions.Count - 1) * 50 + 200 + 70;

            for(int i = 0; i < studentLessons.Count; i += students.Count)
            {
                var border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Child = new TextBlock() { Text = studentLessons[i].LessonDate.ToString("dd.MM"), TextAlignment = TextAlignment.Center }
                };
                grdMarks.Children.Add(border);
                border.SetValue(Grid.ColumnProperty, i / students.Count + 2);
            }

            for (int i = 0; i < students.Count; i++)
            {
                var border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Child = new TextBlock() { Text = students[i].FullName }
                };
                grdMarks.Children.Add(border);
                border.SetValue(Grid.RowProperty, i + 1);
            }

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                var avg = studentLessons.Where(x => x.StudentId == student.Id && x.MarkId != Guid.Parse("B13E6810-878B-45F2-B804-70D6498D7788")).Average(x => _markValues[x.MarkId]);
                var border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Child = new TextBlock() { Text = avg.ToString("0.00") }
                };
                grdMarks.Children.Add(border);
                border.SetValue(Grid.RowProperty, i + 1);
                border.SetValue(Grid.ColumnProperty, 1);
            }

            for (int i = 0; i < students.Count; i++)
            {
                var currentStudentLessons = studentLessons.Where(x => x.StudentId == students[i].Id).ToList();
                for (int j = 0; j < currentStudentLessons.Count; j++)
                {
                    var cbx = new ComboBox()
                    {
                        ItemsSource = _marks,
                        DataContext = currentStudentLessons[j],
                        DisplayMemberPath = "ShortName",
                        SelectedValuePath = "Id",
                        Style = (Style)App.Current.FindResource("CustomCombobox"),
                        Margin = new Thickness(1)
                    };
                    var binding = new Binding { Path = new PropertyPath("MarkId") };
                    BindingOperations.SetBinding(cbx, ComboBox.SelectedValueProperty, binding);
                    cbx.SelectionChanged += cbxMark_SelectionChanged;

                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Child = cbx
                    };
                    grdMarks.Children.Add(border);
                    border.SetValue(Grid.RowProperty, i + 1);
                    border.SetValue(Grid.ColumnProperty, j + 2);
                }
            }
        }

        private async void cbxMark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var studentLesson = (StudentLesson)((ComboBox)sender).DataContext;
            var markId = (Guid)((ComboBox)sender).SelectedValue;

            var client = new HttpClient();
            await client.PutAsync($"https://localhost:7043/api/StudentLessons/SetMark?studentLessonId={studentLesson.StudentLessonId}&markId={markId}", null);
        }
    }
}

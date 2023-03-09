using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using Color = Avalonia.Media.Color;

namespace UITestsForProgressTable
{
    public class UnitTests
    {
        [Fact]
        public async void colors_tests_red()
        {
            var app = AvaloniaApp.GetApp();
            var mWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var Items = mWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var BoxItem = Items.ToArray()[0];
            var Border = BoxItem.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlock = BoxItem.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlock.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (Border.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void color_tests_green()
        {
            var app = AvaloniaApp.GetApp();
            var mWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var Items = mWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var Box = Items.ToArray()[1];
            var Border = Box.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlock = Box.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlock.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (Border.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void color_tests_yellow()
        {
            var app = AvaloniaApp.GetApp();
            var mWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var grid = mWindow.GetVisualDescendants().OfType<Grid>().First(x => (x.Name != null) && x.Name.Equals("SrGrid"));

            var Border = grid.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualSrBorder"));
            var textBlock = grid.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualSrText"));
            var text = textBlock.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (Border.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void student_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var Items = mWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentButton");
            var buttonS = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonL = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            var textbox = mWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonS.Command.Execute(buttonS.CommandParameter);
            textbox.Text = "Иван Иванов";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);
            buttonL.Command.Execute(buttonL.CommandParameter);
            string text = Items.Count().ToString();
            Assert.True(Items.Count() == 3, text);
        }

        [Fact]
        public async void remove_student_test()
        {
            var app = AvaloniaApp.GetApp();
            var mWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mWindow.GetVisualDescendants().OfType<ListBox>().First();

            var Items = listBox.GetVisualDescendants().OfType<ListBoxItem>();

            var buttonRm = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "RemoveStudentButton");
            var buttonS = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveButton");
            var buttonL = mWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "LoadButton");

            buttonS.Command.Execute(buttonS.CommandParameter);
            listBox.SelectedIndex = 0;
            buttonRm.Command.Execute(buttonRm.CommandParameter);

            Assert.True(Items.Count() == 2);

            buttonL.Command.Execute(buttonL.CommandParameter);
        }
    }
}